    var user = validationContext.ObjectInstance as User;
    if(user==null) return new ValidationResult("...");
    using(var db=new SomeDbContext()){
        var has=db.User.Any(x=>x.Id!=user.Id && x.email==value);
        if (has) return new ValidationResult("...");
        else return ValidationResult.Success;
    }
