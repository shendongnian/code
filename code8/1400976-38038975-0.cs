    var searchResults = "http://google.com/search?q=" + textBox1.Text.Trim();
    
    HttpWebResponse response = null;
    var request = (HttpWebRequest)WebRequest.Create(searchResults);
    request.Method = "GET";
    request.Proxy = new WebProxy("http://92.46.122.98:3128", true);
    
    try
    {
        response = (HttpWebResponse) request.GetResponse();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Proxy server is probably do not working. Error message: "+ex.Message);
    }
    
    if (response != null)
    {
        MessageBox.Show("Job done!");
    }
