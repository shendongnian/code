    string username;
    username = User.Identity.Name;
    message.Text = "Welcome " + username;
    HttpClientCertificate cert = Request.ClientCertificate;
    if (cert.IsPresent)
    {
      certData.Text = "Client certificate retrieved";
    }
    else
    {
      certData.Text = "No client certificate";
    }
