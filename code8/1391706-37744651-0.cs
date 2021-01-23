        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            if(CollectionId.HasValue)
                testMethod = WrapTestMethod(testMethod, CollectionId.Value);
            if (!Process.GetCurrentProcess().ProcessName.Equals(Path.GetFileNameWithoutExtension(_ExePath), StringComparison.OrdinalIgnoreCase))
            {
                yield return new XUnitRemoteTestCase(_DiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), testMethod, _Id, _ExePath);
            }
            else
            {
                foreach (var testCase in _DefaultTestCaseDiscoverer.Discover(discoveryOptions, testMethod, factAttribute))
                {
                    yield return _TestCaseConverter(testCase);
                }
            }
        }
