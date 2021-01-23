    static string myip;
    static DateTime ipstamp;
    ...
    if(myip == null||DateTime.Now-ipstamp> TimeSpan.FromHours(10))
    {
       using (System.Net.WebClient wc = new System.Net.WebClient())
         {
             // Take long time to respond.
             myip = wc.DownloadString("http://icanhazip.com/"); 
             ipstamp = DateTime.Now;
         }
    }
