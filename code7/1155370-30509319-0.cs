    public class ParentValidator : AbstractValidator<Parent> 
    {
        public ParentValidator()
        {
            RuleFor(x => x.Children)
                .SetCollectionValidator(new ChildValidator())
                .Must(coll => coll.Sum(item => item.Percentage) == 100);
        }
    }
