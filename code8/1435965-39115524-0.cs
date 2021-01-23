        [TestMethod]
        public void GivenValidPassword_WhenCheckPassword_ThenReturnTrue(){
             var password= "12345678";
        
             var sut = new PasswordChecker();
             var result = sut.CheckPassword(password);
        
              Assert.IsTrue(result );   
        }
    
        [TestMethod]
        public void GivenPasswordLessThan8Characters_WhenCheckPassword_ThenReturnFalse(){
             var password= "1278";
        
             var sut = new PasswordChecker();
             var result = sut.CheckPassword(password);
        
              Assert.IsFalse(result );   
        }
    
        [TestMethod]
        public void GivenPasswordStartWithSpace_WhenCheckPassword_ThenReturnFalse(){
             var password= " 12345678";
        
             var sut = new PasswordChecker();
             var result = sut.CheckPassword(password);
        
              Assert.IsFalse(result );   
        }
