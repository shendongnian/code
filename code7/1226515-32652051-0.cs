    void mButtonCreateContact_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("http://www.mydomainname.com/abcd.php");
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Name", txtName.Text);
            parameters.Add("Number", txtNumber.Text);
            client.UploadValuesCompleted += client_UploadValuesCompleted;
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.UploadValuesAsync(uri, "POST", parameters);          
        }
