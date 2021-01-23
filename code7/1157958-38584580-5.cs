    [TestClass]
    public class PaxiumPricipalCreatorTests
    {
        [TestMethod]
        public void Returns_NULL_principal_when_IFormsAuthentication_returns_null()
        {
            var mockAuthenticator = new NullReturningFormsAuthentication();
            var principalCreator = new PaxiumPricipalCreator(mockAuthenticator);
            var actual = principalCreator.CreatePrincipalFromCookie(string.Empty);
            Assert.IsNull(actual);
        }
        public class NullReturningFormsAuthentication : IFormsAuthentication
        {
            public FormsAuthenticationTicket Decrypt(string cookieValue)
            {
                return null;
            }
        }
    }
