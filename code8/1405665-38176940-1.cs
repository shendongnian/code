    using System;
    using System.Net;
    
    namespace ConsoleApplication1
    {
      internal class Program
      {
        private static void Main(string[] args)
        {
          using (var webClient = new WebClientTimeOut())
          {
            try
            {
              var response = webClient.DownloadString("http://www.go1ogle.com");
              Console.WriteLine(response);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.ToString());
            }
          }
        }
      }
    
      public class WebClientTimeOut : WebClient
      {
        protected override WebRequest GetWebRequest(Uri uri)
        {
          var w = base.GetWebRequest(uri);
          w.Timeout = 1000;  // Timeout 1 second
          return w;
        }
      }
    }
