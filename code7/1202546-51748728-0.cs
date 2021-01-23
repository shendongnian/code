    public static class ViewModelExtensions
    {
        public static IReadOnlyCollection<ValidationResult> GetValidationResults<T>(this T viewModel, Func<Type, object> serviceProvider = null)
        {
            var result = GetComponentValidationResults(viewModel, serviceProvider);
            var modelValidationResults = GetModelValidationResults(viewModel);
            return result
                .Concat(modelValidationResults.ToValidationResults())
                .ToList();
        }
        private static List<ValidationResult> GetComponentValidationResults<T>(T viewModel, Func<Type, object> serviceProvider)
        {
            var vc = new ValidationContext(viewModel);
            if (serviceProvider != null)
            {
                vc.InitializeServiceProvider(serviceProvider);
            }
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(viewModel, vc, result, true);
            return result;
        }
        private static IEnumerable<ModelValidationResult> GetModelValidationResults<T>(T model)
        {
            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(T));
            /* build a stub controller context */
            var controllerContext = Fake.ControllerContext.Build();
            var validator = ModelValidator.GetModelValidator(modelMetadata, controllerContext);
            return validator.Validate(null);
        }
        private static IEnumerable<ValidationResult> ToValidationResults(this IEnumerable<ModelValidationResult> results)
        {
            return results.Select(r => r.ToValidationResult());
        }
        private static ValidationResult ToValidationResult(this ModelValidationResult result)
        {
            return new ValidationResult(result.Message, new[] {result.MemberName});
        }
    }
