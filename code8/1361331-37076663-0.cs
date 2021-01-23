            IApiExplorer apiExplorer = configuration.Services.GetApiExplorer();
            foreach (ApiDescription api in apiExplorer.ApiDescriptions)
            {
                Console.WriteLine("Uri path: {0}", api.RelativePath);
                Console.WriteLine("HTTP method: {0}", api.HttpMethod);
                foreach (ApiParameterDescription parameter in api.ParameterDescriptions)
                {
                    Console.WriteLine("Parameter: {0} - {1}", parameter.Name, parameter.Source);
                }
                Console.WriteLine();
            }
