     public class VmSysTestValidator : AbstractValidator<VmSysTestModel>
        {
            public VmSysTestValidator()
            {
                RuleFor(x => x.FirstName).NotNull().WithMessage("First name is required");
                RuleFor(x => x.LastName).NotNull().WithMessage("Last Name is required");
            }
        }
