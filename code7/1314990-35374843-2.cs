    public int found;
    public int notfound;
    public void GetBrokenLinks(WebBrowser website)
    {
       HtmlElementCollection links = website.Document.GetElementsByTagName("a");
       List<Task> tasks = new List<Task>();
       foreach (string element in links)
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
                        Interlocked.Increment(ref found);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        response.Dispose();
                        Interlocked.Increment(ref notfound);
                    }
                }
                ));
            }
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                ae.Handle((e) => { MessageBox.Show(e.ToString()); return true; });
            }
            MessageBox.Show(found.ToString() + ", " + notfound.ToString());
    }
