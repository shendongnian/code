        public class TestPrincipal : ClaimsPrincipal
        {
            public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
            {
            }
        }
        public class TestIdentity : ClaimsIdentity
        {
            public TestIdentity(params Claim[] claims) : base(claims)
            {
            }
        }
then your test shrinks down to:
        [Test]
        public void TestGetName()
        {
            // Arrange
            var sut = new HomeController();
            Thread.CurrentPrincipal = new TestPrincipal(new Claim("name", "John Doe"));
            // Act
            var viewresult = sut.GetName() as ContentResult;
            // Assert
            Assert.That(viewresult.Content, Is.EqualTo("John Doe"));
        }
