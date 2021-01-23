    public class MyValidator
    {
        public MyValidator()
        {
            // default behavior
            Validate();
        
            // works only when RuleSet specified explicitly as "Debug"
            RuleSet("Debug", ()=> {
                Validate();
                FailAndLogErrors();
            })
        
            private void Validate()
            {
                RuleFor(u => u.Age)
                    //... set cascade mode, define rules with error messages
                RuleFor(u => u.LastName)
                    //... set cascade mode, define rules with error messages
                RuleFor(u => u.BirthDate)
                    //... set cascade mode, define rules with error messages
            }
    
            // force failing
            private void FailAndLogErrors()
            {
                RuleFor(m => m)
                    .Must(m => false)
                    .WithName("_fakeProperty_")
                    .OnAnyFailure(m => LogIfFailed(this, m))
            }
        
            private void LogIfFailed(MyValidator validator, CreateAccountBindingModel obj))
            {
                var errors = validator.Validate(obj, "Debug").Errors;
                if (errors.Count > 1) // prevent displaying valid model
                {
                    var fakeError = errors.First(e => e.PropertyName == "_fakeProperty_");
                    errors.Remove(fakeError);
                    WriteErrors(errors);
                }
            }
            private void WriteErrors(IList<ValidationFailure> errors)
            {
                foreach(var e in errors)
                {
                    Debug.WriteLine(e);
                }
                Debug.WriteLine("");
            }
        }
    }
