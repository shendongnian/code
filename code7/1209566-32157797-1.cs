    private void button1_Click(object sender, EventArgs e)
    {
        WebClient proxy = new WebClient();
        string serviceURL =
                string.Format("http://localhost:53215/IBookService.svc/GetBooksNames");
        byte[] data = proxy.DownloadData(serviceURL);
    
        var jsonString = Encoding.UTF8.GetString(data);
        IList<string> bookNames = JArray.Parse(jsonString).ToObject<IList<string>>();
    
        //Do something with the list
        //foreach (string bookName in bookNames)
        //{
            
        //}    
    }
