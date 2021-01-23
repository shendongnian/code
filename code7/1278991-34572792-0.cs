    public ServiceResult<LoginModel> Login(string auth_key)
     {
                var service = new ServiceResult<LoginModel>();
                LoginModel user = new LoginModel();
                if (AuthKey.CheckAuthorizationKey(auth_key) == false)
                {
                    service.message = TemplateCodes.GetMessage(TemplateCodes.UnAuthorize, null, db);
                    service.status = ServiceStatus.authorization_failed;
                    return service;
                }
