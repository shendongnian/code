    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ATMSimulator
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Please enter the URL to send the XML File");
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Console.ReadLine());
                    byte[] bytes;
                    Console.WriteLine("Please enter the XML File you Wish to send");
                    bytes = Encoding.ASCII.GetBytes(Console.ReadLine());
                    request.ContentType = "text/xml; encoding='utf-8'";
                    request.ContentLength = bytes.Length;
                    request.Method = "POST";
                    request.Timeout = 20000;
                    request.KeepAlive = false;
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
    
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream responseStream = response.GetResponseStream();
                        string responseStr = new StreamReader(responseStream).ReadToEnd();
                    }
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("An Error Occured" + Environment.NewLine + e);
                    Console.ReadLine();
                }
            }
        }
    }    
