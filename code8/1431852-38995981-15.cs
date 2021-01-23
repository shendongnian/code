    public partial class MiscUnitTests {
        [TestClass]
        public class IdentityTests : MiscUnitTests {
            Mock<IPrincipal> mockPrincipal;
            string username = "test@test.com";
            [TestInitialize]
            public override void Init() {
                //Arrange                
                var identity = new GenericIdentity(username, "");
                var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, username);
                identity.AddClaim(nameIdentifierClaim);
                mockPrincipal = new Mock<IPrincipal>();
                mockPrincipal.Setup(x => x.Identity).Returns(identity);
                mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);
            }
            [TestMethod]
            public void Should_GetUserId_From_Identity() {
                var principal = mockPrincipal.Object;
                //Act
                var result = principal.Identity.GetUserId();
                //Asserts
                Assert.AreEqual(username, result);
            }
            [TestMethod]
            public void Identity_Should_Be_Authenticated() {
                var principal = mockPrincipal.Object;
                //Asserts
                Assert.IsTrue(principal.Identity.IsAuthenticated);
            }
        }
    }
