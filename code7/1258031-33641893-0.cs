    WebServiceHost host = new ServiceHost(typeof(CloudService), httpUri);
    host.Description.Behaviors.Find<ServiceCredentials>().UserNameAuthentication
        .UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
    host.Description.Behaviors.Find<ServiceCredentials>().UserNameAuthentication
        .CustomUserNamePasswordValidator = new ServiceUserNamePasswordValidator(repositoryConnectionString);
