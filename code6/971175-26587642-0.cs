     public class Downloader
        {
          public void DownloadFile()
          {
             using(WebClient webClient = new WebClient())
             {
                 webClient.DownloadFile("http://www.stackoverflow.com/stacks.txt", @"c:\stacks.txt");
             }
          }
        } 
