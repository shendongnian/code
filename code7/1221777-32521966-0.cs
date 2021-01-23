     WebRequest myReq = WebRequest.Create(rowss.Url);
     string usernamePassword = "username" + ":" + "password";
     usernamePassword = Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)); // <--- here.
     CredentialCache mycache = new CredentialCache();
     myReq.Credentials = mycache;
     myReq.Headers.Add("Authorization", "Basic " + usernamePassword);
