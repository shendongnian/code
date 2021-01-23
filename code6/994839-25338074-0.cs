    private void btnSubmit_Click(object sender, EventArgs e)
    {  
        WebRequest request = null;
        HttpWebResponse response = null;
        Stream stream = null;
        StreamReader reader = null;
        string url = txtURL.Text.ToString();
        if (url != "")
        {
            try
            {
                // Display Please Wait Image
                Form1.Show();
    
                string NavigateURL = "http://" + url + Properties.Settings.Default.portAppName;
                request = HttpWebRequest.Create(NavigateURL + "connectionParam/PostCon");
                request.Method = "POST";
                request.ContentType = "text/xml";
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Form1.Dispose();
                    // My stuff
                }
            }
            catch(Exception ex)
            { }
        }
    }
