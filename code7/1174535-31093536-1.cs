    private enum Status { Pending, FoundUnprocessed, FoundProcessed, NotFoundNotProcessed, NotFoundProcessed }
    private List<Status>   URLStatuses = new List<bool>() ;
    private List<string>   URLs        = new List<string>() ;
 
  
    private void StartUrlsThreads()
    {
      for (int i = 0; i < int.Parse(label2.Text); i++)
      {
         URLs.Add(dataGridView1[0, i].Value.ToString());
         URLStatuses.Add(false) ; 
         Thread newThread = new Thread(new ThreadStart(URLExists));
         newThread.Start(URLs[i]) ;
      }
    }
    private void URLExists(object urlobj)
    {
      try
      {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create((string)urlobj);
        request.Method = WebRequestMethods.Http.Head;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
           response.Close();
           URLStatuses[URLs.IndexOf((string)urlobj)]=Status.FoundUnprocessed ;
        }
        else URLStatuses[URLs.IndexOf((string)urlobj)]=Status.NotFoundUnprocessed ;
      }       
      catch { URLStatuses[URLs.IndexOf((string)urlobj)]=Status.NotFoundUnprocessed ; }
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
      for (int i=0;i<URLs.Count;i++) 
      {
        if (URLStatuses[i]==Status.FoundUnprocessed) 
        {
	   URLStatuses[i]==Status.FoundProcessed ;
           // update DataGridView && progressbar
        }
        if (URLStatuses[i]==Status.NotFoundUnprocessed) 
        {
	   URLStatuses[i]==Status.NotFoundProcessed ;
           // update DataGridView && progressbar
        }
    // stop timer if no more pending status
    }
