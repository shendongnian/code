    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Net;
    using System.IO;
    
    namespace AccessAPI
    {
        class Program
        {
            static void Main(string[] args)
            {
                string uri = "http://domain.name/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.UseDefaultCredentials = false;
                request.PreAuthenticate = true;
                request.Credentials = new NetworkCredential("username", "password");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
