    private bool Ping(string url, Label label)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Timeout = 3000;
            request.AllowAutoRedirect = false;
            request.Method = "HEAD";
    
            using (var response = request.GetResponse())
            {
                label.Text = "Online";
                label.ForeColor = Color.LimeGreen;
                return true;
            }
        }
        catch
        {
            label.Text = "Offline";
            label.ForeColor = Color.DarkRed;
            return false;
        }
    }
