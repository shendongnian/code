    [TestClass]
    public class PasswordCheckerTests
    {
        [TestMethod]
        public void CheckPassword_PasswordLessThanEightCharacters_ReturnsFalse()
        {
            string invalidPassword = "1234567";
            PasswordChecker checker = new PasswordChecker();
            Assert.IsFalse(checker.CheckPassword(invalidPassword));
        }
        [TestMethod]
        public void CheckPassword_PasswordLongerThanSevenCharacters_ReturnsTrue()
        {
            string validPassword= "12345678";
            PasswordChecker checker = new PasswordChecker();
            Assert.IsTrue(checker.CheckPassword(validPassword));
        }
    }
