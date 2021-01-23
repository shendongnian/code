    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    
    namespace NetworkTracing
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{			
    			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
    			request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
    			using (WebResponse response = request.GetResponse())
                {
                    using (Stream strumien = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(strumien))
                        {
                        	var res = sr.ReadToEnd();
                        	Console.WriteLine("Send -> {0}",NetworkListner.BytesSent);
                        	Console.WriteLine("Recieve -> {0}",NetworkListner.BytesReceived);
                        	Console.ReadLine();
                        }
                    }
                }
    		}
    	}
