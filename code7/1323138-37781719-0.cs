    SHA1CryptoServiceProvider crypto = new SHA1CryptoServiceProvider();
    byte[] bytes = new byte[16];
    Array.Copy(crypto.ComputeHash(Encoding.Unicode.GetBytes(automationTestName)), bytes, bytes.Length);
    Guid automationGuid = new Guid(bytes);
     testCase.Implementation = testCase.Project.CreateTmiTestImplementation(
                automationTestName, automationTestType,
                automationStorageName, automationGuid);
    testCase.Save(); 
