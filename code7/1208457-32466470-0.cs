    MundoNetElements.LoggingService service = new LoggingService();
                if (service == null)
                {
                    service = new MundoNetElements.LoggingService();
                    service.Update();
                    if (service.Status != SPObjectStatus.Online)
                        service.Provision();
                }
