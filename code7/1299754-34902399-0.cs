    private static void SetupIoCInValidationContext(
            IServiceProvider serviceProvider)
        {
            IEnumerable<ModelValidatorProvider> modelValidatorProviders =
                GlobalConfiguration
                .Configuration.Services.GetModelValidatorProviders();
            DataAnnotationsModelValidatorProvider provider =
                (DataAnnotationsModelValidatorProvider)
                    modelValidatorProviders.Single(
                        x =>
                            x.GetType()
                                .IsTypeOf(
                                    typeof(DataAnnotationsModelValidatorProvider)));
            provider.RegisterDefaultAdapterFactory((providers, attribute) =>
                new CustomDataAnnotationsModelValidator(providers, attribute,
                    serviceProvider));
            provider.RegisterDefaultValidatableObjectAdapterFactory(
                providers => new CustomValidatableObjectAdapter(providers, serviceProvider)
                );
        }
