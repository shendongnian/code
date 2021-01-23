    public class MyObjValidator : AbstractValidator<MyObj> {
            public MyObjValidator()
            {
                // Other rules for my object
                // .
                // .
                RuleFor(o => o.Email)
                    .NotEmpty()
                    .Must(BeNonBannedDomain)
                    .WithMessage("Please specify a valid email address");
            }
            private bool BeNonBannedDomain(string email)
            {
                var domainName = GetDomainName(email); // a method to extract the dmain name from the email
                return !someListOfBannedDomains.Contains(domainName); // a list of all the banned domains that I need to check against.
            }
        }
