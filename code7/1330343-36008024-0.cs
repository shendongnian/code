    FluentValidation.AssemblyScanner.FindValidatorsInAssemblyContaining<UserPayloadValidator>()
                .ForEach(result =>
                {
                    container.Register(result.InterfaceType, result.ValidatorType);
                });
