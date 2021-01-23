    
    HelloServiceClient client = new HelloServiceClient();
    client.ClientCredentials.UserName.UserName = userName;
    client.ClientCredentials.UserName.Password = password;
    String msg = client.SayHello(userName);
