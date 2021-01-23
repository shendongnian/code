    FluentValidation.AssemblyScanner findValidatorsInAssembly = FluentValidation.AssemblyScanner.FindValidatorsInAssembly(typeof(UserPayloadValidator).Assembly);
                foreach (FluentValidation.AssemblyScanner.AssemblyScanResult item in findValidatorsInAssembly)
                {
                    container.Register(item.InterfaceType, item.ValidatorType);
                }
