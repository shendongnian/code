    // validator class for your view model
    public class MyModelValidator : AbstractValidator<MyModel>
    {
        public MyModelValidator()
        {
            RuleFor(m => m.EndDate).NotNull().WithMessage("Please enter an End Date");
            RuleFor(m => m.StartDate).NotNull().WithMessage("Please enter a Start Date")
                .LessThan(m => m.EndDate).WithMessage("Start Date must preceed End Date");
        }
    }
    // declare MyModelValidator as a validator for view model
    [Validator(typeof(MyModelValidator))]
    public class MyModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
