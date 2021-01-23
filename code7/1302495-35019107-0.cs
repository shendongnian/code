     public class Persons : List<Person>
    {
    public void ValidateAndThrow()
            {
                var errors = new List<ValidationFailure>();
                try
                {
                    var persons = this.Where(element => element.SSN.Trim().Length > 0);
                    var allSSNs = persons.Select(element => element.SSN.Trim());
                    if (allSSNs.Count() > allSSNs.Distinct().Count())
                    {
                        var validationFailure = new ValidationFailure("UniqueSSNsInHouseHold", "SSN's in a household should be unique");
                        errors.Add(validationFailure);
                    }         
                }
                catch (Exception ex)
                {
                }
    
                if (errors.Any())
                {
                    throw new ValidationException(errors);
                }
            }
    }
