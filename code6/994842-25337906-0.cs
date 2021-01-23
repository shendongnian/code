    // No constraint on V - why would you need one?
    public class ValidatorHelper<T, V> : AbstractValidator<V> 
            where T : AbstractValidator<V>
    {
        public bool Validate(T validator, V value)
        {
            ValidationResult results = validator.Validate(nvalue);
            if (!results.IsValid)
            {
                StringBuilder errorMessage = new StringBuilder("Data Validation Checking Error:\n");
                foreach (var failure in results.Errors)
                {
                    errorMessage.AppendLine("- " + failure.ErrorMessage);
                }
                MessageBox.Show(errorMessage.ToString(), "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
