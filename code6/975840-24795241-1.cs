    String serviceAccountEmail =
        "999999999-9nqenknknknpmdvif7onn2kvusnqct2c@developer.gserviceaccount.com";
    var certificate = new X509Certificate2(
        AppDomain.CurrentDomain.BaseDirectory +
            "certs//fe433c710f4980a8cc3dda83e54cf7c3bb242a46-privatekey.p12",
        "notasecret",
        X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
    string userEmail = "user@domainhere.com.au";
    ServiceAccountCredential credential = new ServiceAccountCredential(
        new ServiceAccountCredential.Initializer(serviceAccountEmail)
        {
            User = userEmail,
            Scopes = new[] { "https://mail.google.com/" }
        }.FromCertificate(certificate)
    );
    if (credential.RequestAccessTokenAsync(CancellationToken.None).Result)
    {   
        GmailService gs = new GmailService(
            new Google.Apis.Services.BaseClientService.Initializer()
            {
                ApplicationName = "iLink",
                HttpClientInitializer = credential
            }
        );
        UsersResource.MessagesResource.GetRequest gr =
            gs.Users.Messages.Get(userEmail, msgId);
        gr.Format = UsersResource.MessagesResource.GetRequest.FormatEnum.Raw;
        Message m = gr.Execute();
        if (gr.Format == UsersResource.MessagesResource.GetRequest.FormatEnum.Raw)
        {
            byte[] decodedByte = FromBase64ForUrlString(m.Raw);
            string base64Encoded = Convert.ToString(decodedByte);
            MailMessage msg = new MailMessage();
            msg.LoadMessage(decodedByte);
        }
    }
