    [TestClass]
    public class MiscUnitTest {
        [TestMethod]
        public async Task MyManager_TestIdentity_With_User_Should_Return_AdminRole() {
            //Arrange
            string username = "user";
            string expectedRole = "admin";
            var mockIMyRespository = new Mock<IMyRespository>();
            mockIMyRespository.Setup(p => p.GetRole(It.IsAny<string>())).
            ReturnsAsync(new RoleObject() {
                Name = expectedRole
            });
            var sut = new MyManager(mockIMyRespository.Object);
            //Act
            var result = await sut.TestIdentity(username);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Role);
            Assert.AreEqual(expectedRole, result.Role.Name);
        }
    }
