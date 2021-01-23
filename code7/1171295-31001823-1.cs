  
    string userName;
    userName = User.Identity.Name;
    greetingLabel.Text = "Welcome " + userName;
    HttpClientCertificate cert = Request.ClientCertificate;
    if (cert.IsPresent)
        certDataLabel.Text = cert.Get("SUBJECT O");
    else
        certDataLabel.Text="No certificate was found.";
