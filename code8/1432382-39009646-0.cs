    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using 12kiajunPA03;
    
    namespace PasswordCheckerTest
    {
        [TestClass]
        public class PasswordCheckerTest
        {
            [TestMethod]
            public void Checkpassword8CharsLong()
            {
                string validPassword = "12345678";
                string invalidPassword = "abc";
    
                PasswordChecker checker = new PasswordChecker();
        
                Assert.IsTrue(checker.CheckPassword(validPassword));
                Assert.IsFalse(checker.CheckPassword(invalidPassword));
            }
        }
    }
