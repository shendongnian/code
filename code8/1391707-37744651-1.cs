        private ITestMethod WrapTestMethod(ITestMethod testMethod, Guid uniqueId)
        {
            var testClass = testMethod.TestClass;
            var testCollection = testClass.TestCollection;
            testCollection = new TestCollection
                (testCollection.TestAssembly, testCollection.CollectionDefinition, testCollection.DisplayName)
            {
                UniqueID = uniqueId
            };
            testClass = new TestClass(testCollection, testClass.Class);
            testMethod = new TestMethod(testClass, testMethod.Method);
            return testMethod;
        }
