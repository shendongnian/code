    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int age)
        {
            MinimumAge = age;
        }
        protected int MinimumAge { get; set; }
    }
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override void Handle(AuthorizationContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth &&
                                       c.Issuer == "http://contoso.com"))
            {
                return;
            }
            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(
                c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com").Value);
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }
            if (calculatedAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }
        }
    }
