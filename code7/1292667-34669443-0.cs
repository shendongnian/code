    // Setup the inline validator and ruleset
    var validator = new InlineValidator<Person>();
    
    validator.RuleSet("test", () =>
    {
        validator.RuleFor(x => x.Name).NotNull();
        validator.RuleFor(x => x.Age).NotEqual(0);
    });
    
    var person = new Person();
    // Validate against the RuleSet specified above
    var validationResult = validator.Validate(person, ruleSet: "test");    
    Console.WriteLine(validationResult .IsValid); // Prints False
