    using System;
    using System.IO;
    using System.Net;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                HttpWebRequest htwr = (HttpWebRequest)WebRequest.Create("[any url that can get an http connection]");
                WebResponse response = htwr.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                response.Close();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
    
            }
        }
    }
