     PlusService service = new PlusService(new BaseClientService.Initializer()
                                {
                                  HttpClientInitializer = credential,
                                  ApplicationName = "Google Plus Sample",
                                });
                           return service;
