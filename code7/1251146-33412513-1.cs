    [TestFixture]
    public class UserControllerTest
    { 
        [Test]
        public void DeleteTest()
        {
            var ObjUser = new Mock<IUserRepository>();
    
            ObjUser.Setup(X => X.DeleteUser(It.IsAny<long>())).Returns(true);
    
            var Result = new UserController(ObjUser.Object).Delete(1);
            Assert.That(Result, //is expected view result with expected model);
            Assert.That(ObjUser.Verify(), Is.True);        
        }        
    
        [Test]
        public void CreateTest()
        {
            tbl_Users User = new tbl_Users();
            Mock<IUserRepository> MockIUserRepository = new Mock<IUserRepository>();
            MockIUserRepository.Setup(X => X.CreateUser(It.IsAny<tbl_Users>())).Returns(true);
    
            var Result = var Result = new UserController(ObjUser.Object).Create(User);;
    
            Assert.That(Result, //is a view result with expected view model);
            Assert.That(ObjUser.Verify(), Is.True); 
        }         
    }
