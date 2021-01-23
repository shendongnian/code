    public class Person {
    	public string FirstName { get; set; }
    }
    
    public class PersonValidator : AbstractValidator<Person> {
    	public PersonValidator() {
    		RuleFor(x => x.FirstName).NotNull().WithMessage("Can't be null");
    		RuleFor(x => x.FirstName).Length(1, 100).WithMessage("Too short or long");
    		RuleFor(x => x.FirstName).Matches("^([a-zA-Z0-9 .&'-]+)$").WithMessage("Invalid First Name"));
    	}
    }
