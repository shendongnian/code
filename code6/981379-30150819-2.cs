    public class ContainerValidator : AbstractValidator<ContainerClass>
    {
        public ContainerValidator()
        {
            RuleFor(model => model.Collection)
                .SetCollectionValidator(new CommonBaseClassValidator());
        }
    }
