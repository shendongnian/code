     try
            {
                AceVqbzServiceClient aceVqbzClientService = new AceVqbzServiceClient();
                aceVqbzClientService.OpenAsync();
                IAceVqbzService aceVqbzTypeService = aceVqbzClientService as IAceVqbzService;
                var asyncResult = aceVqbzTypeService.BeginSaveUserOrganizationLinking( objUser_OrganizationDetail, null, null );
                asyncResult.AsyncWaitHandle.WaitOne();
            }
            catch ( Exception ex )
            {
                throw;
            }
