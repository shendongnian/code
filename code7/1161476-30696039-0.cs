    using (WebClient webClient = new WebClient())
    {
        webClient.Credentials = new NetworkCredential(
                                    ConfigurationManager.AppSettings["ftp_user"].ToString(),
                                    ConfigurationManager.AppSettings["ftp_pass"].ToString());
        webClient.UploadFile("ftp://address.toserver.com", "STOU", "PathToLocalFile");
    }
