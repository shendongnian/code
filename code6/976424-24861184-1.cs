    // This intentionally does not derive from AutoDataAttribute to avoid
    // double-processing from the Autofixture NUnit2 addin.
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    class AutoMoqDataAttribute : Attribute
    {
        readonly AutoDataAttribute _autoDataAttr;
        public AutoMoqDataAttribute()
        {
            this._autoDataAttr = new AutoDataAttribute(new Fixture().Customize(new AutoMoqCustomization()));
        }
        public IEnumerable<object[]> GetData(MethodInfo method)
        {
            return this._autoDataAttr.GetData(method);
        }
    }
    [NUnitAddin]
    public class AutoMoqDataAddIn : IAddin
    {
        public bool Install(IExtensionHost host)
        {
            IExtensionPoint testCaseProviders = host.GetExtensionPoint("TestCaseProviders");
            if (testCaseProviders == null)
            {
                return false;
            }
            testCaseProviders.Install(new AutoMoqDataProvider());
            ReplaceTestCaseProvidersWithWrapper(testCaseProviders);
            return true;
        }
        static void ReplaceTestCaseProvidersWithWrapper(IExtensionPoint testCaseProviders)
        {
            // This may break in future versions of NUnit 2.6. It will definitely fail in NUnit 3.0
            var extensionsField = testCaseProviders
                .GetType()
                .GetProperty("Extensions", BindingFlags.NonPublic | BindingFlags.Instance);
            if (extensionsField == null)
            {
                throw new Exception(
                    string.Format(
                        "'{0}' does not have a property called 'Extensions'. Incompatible NUnit version, please update your add-in.",
                        testCaseProviders.GetType().FullName));
            }
            var extensions = (ExtensionsCollection)extensionsField.GetValue(testCaseProviders);
            var testCaseParameterProvider = extensions.OfType<TestCaseParameterProvider>().FirstOrDefault();
            var testCaseSourceProvider = extensions.OfType<TestCaseSourceProvider>().FirstOrDefault();
            if (testCaseParameterProvider == null)
            {
                throw new Exception(
                    string.Format(
                        "Could not find an instance of '{0}' in the test case providers lists. Incompatible NUnit version, please update your add-in.",
                        typeof(TestCaseParameterProvider).FullName));
            }
            if (testCaseSourceProvider == null)
            {
                throw new Exception(
                    string.Format(
                        "Could not find an instance of '{0}' in the test case providers lists. Incompatible NUnit version, please update your add-in.",
                        typeof(TestCaseSourceProvider).FullName));
            }
            extensions.Remove(testCaseParameterProvider);
            extensions.Remove(testCaseSourceProvider);
            extensions.Add(
                new TestCaseProviderAutoMoqDataFilterWrapper(
                    testCaseParameterProvider,
                    typeof(TestCaseAttribute)));
            extensions.Add(
                new TestCaseProviderAutoMoqDataFilterWrapper(testCaseSourceProvider,
                    typeof(TestCaseSourceAttribute)));
        }
        /// <summary>
        /// Wraps a <see cref="TestCaseParameterProvider" /> or <see cref="TestCaseSourceProvider" /> to 
        /// cause it to be skipped when the test method being evaluated has a <see cref="AutoMoqDataAttribute" />
        /// to avoid a conflict with <see cref="AutoMoqDataProvider" /> which will handle their processing instead.
        /// </summary>
        class TestCaseProviderAutoMoqDataFilterWrapper : ITestCaseProvider
        {
            readonly ITestCaseProvider _testCaseProvider;
            readonly Type _attributeType;
            public TestCaseProviderAutoMoqDataFilterWrapper(ITestCaseProvider testCaseProvider, Type attributeType)
            {
                if (testCaseProvider == null)
                {
                    throw new ArgumentNullException("testCaseProvider");
                }
                if (attributeType == null)
                {
                    throw new ArgumentNullException("attributeType");
                }
                if (!(testCaseProvider is TestCaseParameterProvider || testCaseProvider is TestCaseSourceProvider))
                {
                    throw new ArgumentException(
                        string.Format("Argument must be an instance of {0} or {1}",
                            typeof(TestCaseParameterProvider).FullName,
                            typeof(TestCaseSourceProvider).FullName),
                        "testCaseProvider");
                }
                this._testCaseProvider = testCaseProvider;
                this._attributeType = attributeType;
            }
            public bool HasTestCasesFor(MethodInfo method)
            {
                return Reflect.HasAttribute(method, this._attributeType.FullName, false)
                       && !Reflect.HasAttribute(method, typeof(AutoMoqDataAttribute).FullName, false);
            }
            public IEnumerable GetTestCasesFor(MethodInfo method)
            {
                return this._testCaseProvider.GetTestCasesFor(method);
            }
        }
    }
    class AutoMoqDataProvider : ITestCaseProvider2
    {
        public bool HasTestCasesFor(MethodInfo method)
        {
            return this.HasTestCasesFor(method, null);
        }
        public IEnumerable GetTestCasesFor(MethodInfo method)
        {
            return this.GetTestCasesFor(method, null);
        }
        public bool HasTestCasesFor(MethodInfo method, Test suite)
        {
            return Reflect.HasAttribute(method, typeof(AutoMoqDataAttribute).FullName, false);
        }
        public IEnumerable GetTestCasesFor(MethodInfo method, Test suite)
        {
            var autoMoqDataAttr =
                Reflect.GetAttributes(method, typeof(AutoMoqDataAttribute).FullName, false)
                    .Cast<AutoMoqDataAttribute>()
                    .First();
            IEnumerable<ParameterSet> parameterizedTestCaseParams = Enumerable.Empty<ParameterSet>();
            bool testIsParameterized = false;
            if (Reflect.GetAttributes(method, typeof(TestCaseAttribute).FullName, false).Any())
            {
                var provider = new TestCaseParameterProvider();
                parameterizedTestCaseParams =
                    parameterizedTestCaseParams.Concat(provider.GetTestCasesFor(method).Cast<ParameterSet>());
                testIsParameterized = true;
            }
            if (Reflect.GetAttributes(method, typeof(TestCaseSourceAttribute).FullName, false).Any())
            {
                var provider = new TestCaseSourceProvider();
                parameterizedTestCaseParams =
                    parameterizedTestCaseParams.Concat(provider.GetTestCasesFor(method).Cast<ParameterSet>());
                testIsParameterized = true;
            }
            var autoFixtureResolvedParams = autoMoqDataAttr.GetData(method).First();
            if (!testIsParameterized)
            {
                yield return new ParameterSet { Arguments = autoFixtureResolvedParams };
                yield break;
            }
            foreach (var parameterSet in parameterizedTestCaseParams)
            {
                var numberOfSpecifiedParams = parameterSet.Arguments.Length;
                var mergedParams = parameterSet.Arguments.Concat(autoFixtureResolvedParams.Skip(numberOfSpecifiedParams));
                parameterSet.Arguments = mergedParams.ToArray();
                yield return parameterSet;
            }
        }
    }
