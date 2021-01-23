    private void ValidateId(string id, CustomContext context)
    {
        if (id == "test")
        {
             context.AddFailure("You are testing");
        }
        var idValid = IdValidator.IsValid(id);
        if (!idValid)
        {
            context.AddFailure("Id is invalid");
        }
    }
