    private static void ValidateObject(Person obj){
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(obj, context, results, true);
        if (!isValid)
        {
            throw new InvalidOperationException(results.First().ErrorMessage);
        }        
    }
