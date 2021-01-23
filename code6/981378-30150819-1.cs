    public class CommonBaseClassValidator : AbstractValidator<BaseClass>
    {
        public CommonBaseClassValidator()
        {
            //common rule for all BaseClass types
            RuleFor(x => x.Name)
                .NotEmpty();
            // special rules for base type
            When(model => model.GetType() == typeof (BaseClass), () =>
            {
                RuleFor(x => x.Name)
                    .Length(0, 10);
                // add rules here
            });
            //special rules for derived types
            When(model => model.GetType() == typeof(DerivedClassOne), () =>
            {
                RuleFor(model => ((DerivedClassOne) model).Count)
                    .ExclusiveBetween(1, 9);
                // add rules here
            });
            When(model => model.GetType() == typeof(DerivedClassTwo), () =>
            {
                RuleFor(model => ((DerivedClassTwo) model).Price)
                    .GreaterThan(1000);
                // add rules here
            });
        }
    }
