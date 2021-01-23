    void GetPosts(string UserID)
        {
            WebClient webclient = new WebClient();
            Uri uristring = new Uri("somelink.com");
            webclient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            string postJsonData = string.Empty;
            postJsonData += "userId=" + UserID;//parameters you want to POST
            webclient.UploadStringAsync(uristring, "POST", postJsonData);
            webclient.UploadStringCompleted += webclient_UploadStringCompleted;
        }
        void webclient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            .... // any code
        }
