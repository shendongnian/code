    public class CustomPrinciple : ClaimsPrincipal
    {
        public CustomPrinciple(ClaimsIdentity identity) : base(identity)
        {
        }
        public override bool IsInRole(string role)
        {
            return HasClaim("myRoleClaimType", role);
        }
    }
    [TestClass]
    public class CustomRoleTest
    {
        [TestMethod]
        public void testing_custom_role_type()
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim("myRoleClaimType", "role1"));
            var principle = new CustomPrinciple(identity);
            Assert.IsTrue(principle.IsInRole("role1"));
            Assert.IsFalse(principle.IsInRole("role2"));
        }
    }
