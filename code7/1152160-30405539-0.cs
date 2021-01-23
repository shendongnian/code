    using System;
    using System.IO;
    using System.Net;
    
    class Program
    {
        static void Main(string[] args)
        {
            DateTime prev_date = new DateTime(2015, 4, 1);
            DateTime date = new DateTime(2015, 4, 30);
    
            string url = @"http://www.google.com.cy/search?q=keyword&hl=en-CY&biw=1280&bih=620&source=lnt&tbs=cdr%3A1%2Ccd_min%3A" + 
                prev_date.Month.ToString() + "%2F" + prev_date.Day.ToString() 
                + "%2F" + prev_date.Year.ToString() + "%2Ccd_max%3A" + 
                date.Month.ToString() + "%2F" + date.Day.ToString() + "%2F" + 
                date.Year.ToString() + "&tbm=nws";
    
            WebClient client = new WebClient ();
            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            Stream sr = client.OpenRead(url);
            StreamReader reader = new StreamReader(sr);
            File.WriteAllText(@"C:\Users\Ryan\Desktop\test.htm", reader.ReadToEnd());
            sr.Close ();
        }
    }
