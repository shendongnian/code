    HelloServiceClient client = new HelloServiceClient("basicEndpoint",
        new EndpointAddress("https://testsecurewebservice.azurewebsites.net/HelloService.svc"));
    client.ClientCredentials.UserName.UserName = userName;
    client.ClientCredentials.UserName.Password = password;
    String msg = client.SayHello(userName);
