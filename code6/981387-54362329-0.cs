    public class CommonBaseClassValidator : AbstractValidator<BaseClass>
    {
        public CommonBaseClassValidator()
        {
            //All rules for shared properties
            RuleFor(x => x.Name)
                .NotEmpty();
    		
    		RuleFor(x => x.Name)
                    .Length(0, 10);
    
            //special rules for derived types
            When(model => model.GetType() == typeof(DerivedClassOne), 
    			() => RuleFor(entity => entity as DerivedClassOne)
    					.SetValidator(new DerivedClassOneValidator()));
    
            When(model => model.GetType() == typeof(DerivedClassTwo), 
    			() => RuleFor(entity => entity as DerivedClassTwo)
    				.SetValidator(new DerivedClassTwoValidator()));
        }
    }
