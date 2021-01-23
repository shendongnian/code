    using (WebClient webClient = new WebClient())
    {
        webClient.Credentials = new NetworkCredential(
                                    ConfigurationManager.AppSettings["ftp_user"].ToString(),
                                    ConfigurationManager.AppSettings["ftp_pass"].ToString());
        byte[] response = webClient.UploadFile("ftp://address.toserver.com",
                                               WebRequestMethods.Ftp.UploadFileWithUniqueName, 
                                               "PathToLocalFile");
        var fileName = Encoding.UTF8.GetString(response);
    }
