    public class Parent
    {
        public int Id {get;set;}
        public Child ChildModel {get;set;}
    }
    
    public class Child
    {
        public string Name {get;set;}
        public Parent ParentModel {get;set;}
    }
    
    public class ChildValidator : AbstractValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name should not be null for child of {0}'s parent", (model, value) => model.Parent.Id)
        }
    }
