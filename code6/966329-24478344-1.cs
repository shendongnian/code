    private void btnSayMyName_Click(object sender, EventArgs e)
    {
        string response = SendRequest("http://localhost/whatsmyname.php?name=" + txtMyName.Text);
        
        if(response != null)
        {
            MessageBox.Show(response, "Hey there!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    private string SendRequest(string url)
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(new Uri(url));
            }
        }
        catch(WebException ex)
        {
            MessageBox.Show("Error while receiving data from the server:\n" + ex.Message, "Something broke.. :(", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return null;
        }
    }
  
