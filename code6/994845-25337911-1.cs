    public static class ValidatorHelper<T, V> 
        where T : class, IValidator<V>, new()
        where V : class, new()
    {
        public static bool Validate(T t, V n)
        {
            T validator = new T(); 
            ValidationResult results = validator.Validate(n);
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
