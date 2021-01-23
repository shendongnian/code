    public void GetBrokenLinks(WebBrowser website)
    {
       HtmlElementCollection links = website.Document.GetElementsByTagName("a");
       List<Task> tasks = new List<Task>()
        foreach (HtmlElement element in links)
        {
            string link = element.GetAttribute("href").ToString();
               
            tasks.Add(Task.Factory.StartNew(() =>
                    {
                         Uri urlCheck = new Uri(link);
                         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCheck);
                         request.Timeout = 10000;
                         HttpWebResponse response;
                         response = (HttpWebResponse)request.GetResponse();
                         if (response.StatusCode == HttpStatusCode.OK)
                         {
                             response.Dispose();
                             found++;
                         }
                         else if (response.StatusCode == HttpStatusCode.NotFound)
                         {
                             response.Dispose();
                             notfound++;
                         } 
                     }
             );
        }
        try
        {
        Task.WaitAll(tasks);
        }
        catch(AggregateException e)
        {
            foreach(var innerException in e.InnerExceptions)
            {
                 MessageBox.Show(innerException.ToString());
            }
        }
        MessageBox.Show(found.ToString() + ", " + notfound.ToString());
    }
