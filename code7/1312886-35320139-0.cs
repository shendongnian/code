    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    namespace ReadCSVFromURL
    {
        class Program
        {
            static void Main(string[] args)
            {
                SplitCSV();
            }
            public static string GetCSV(string url)
            {
                ServicePointManager.ServerCertificateValidationCallback = 
                (object a, System.Security.Cryptography.X509Certificates.X509Certificate b, System.Security.Cryptography.X509Certificates.X509Chain c, System.Net.Security.SslPolicyErrors d) => { return true; };            
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
                return results;
            }
            public static void SplitCSV()
            {
                List<string> splitted = new List<string>();
                string fileList = GetCSV("URL");
                string[] tempStr;
                tempStr = fileList.Split(',');
                foreach (string item in tempStr)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        splitted.Add(item);
                    } 
                }
            }
        }
    }
