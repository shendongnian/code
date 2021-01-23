        /// <summary>
        /// Associates an automation to the test case.
        /// </summary>
        /// <param name="testCase">The test case artifact to which to associate automation</param>
        /// <param name="automationTestName">The automation test name. It should be fully
        /// qualified of format "Namespace.ClassName.TestMethodName.</param>
        /// <param name="automationTestType">The automation test type like "CodedUITest".</param>
        /// <param name="automationStorageName">The assembly name containing the above
        /// test method without path like MyTestProject.dll.</param>
        private static ITestCase AssociateAutomation(ITestCase testCase,
            string automationTestName, string automationTestType, string automationStorageName)
        {
            // Build automation guid
            SHA1CryptoServiceProvider crypto = new SHA1CryptoServiceProvider();
            byte[] bytes = new byte[16];
            Array.Copy(crypto.ComputeHash(Encoding.Unicode.GetBytes(automationTestName)), bytes, bytes.Length);
            Guid automationGuid = new Guid(bytes);
    
            // Create the associated automation.
            testCase.Implementation = testCase.Project.CreateTmiTestImplementation(
                    automationTestName, automationTestType,
                    automationStorageName, automationGuid);
    
            // Save the test. If you are doing this for lots of test, you can consider
            // bulk saving too (outside of this method) for performance reason.
            return testCase;
        }
