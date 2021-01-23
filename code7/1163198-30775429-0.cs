    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.Xml;
    using System.Net;
    namespace ConsoleApplication4
    {
        class Program
        {
        int flag = 1;
        string destination;
        string source;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine("**************************** Send HTTP Post Requests **************************");
            int n = 0;
            Program p = new Program();
            Console.WriteLine("Enter the number of requests you want to send at a time");
            string s = Console.ReadLine();
            int.TryParse(s, out n);
            Console.WriteLine("Enter Source");
            p.source = Console.ReadLine();
            Console.WriteLine("Enter Destination");
            p.destination = Console.ReadLine();
            
            string[] files = null;
            files = Directory.GetFiles(p.source, "*.xml", SearchOption.TopDirectoryOnly);
           
            Thread[] thread = new Thread[files.Length];
           
            int len = files.Length;
            for (int i = 0; i<len; i+=n)
            {
                int x = i;
                //Thread.Sleep(5000);
                for (int j = 0; j < n && x < len; j++)
                {
                    
                    var localx = x;
                    thread[x] = new Thread(() => function(files[localx], p));
                    thread[x].Start();
                    Thread.Sleep(50);
                    //thread[x].Join();
                    x++;
                }
                int y = x - n;
                for (; y < x; y++)
                {
                    int t = y;
                    thread[t].Join();
                }
                                
            }
            // thread[0] = new Thread(() => function(files[0]));
            //thread[0].Start();
            Console.ReadKey();
        }
        public static void function(string temp,Program p)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(temp);
            
            string final_d=p.destination + "response " + p.flag + ".xml";
            p.flag++;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.76.22.135/wpaADws/ADService.asmx");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            Stream stream = request.GetRequestStream();
            doc.Save(stream);
            stream.Close();
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader rd = new StreamReader(response.GetResponseStream()))
            {
                string soapResult = rd.ReadToEnd();
                doc.LoadXml(soapResult);
                File.WriteAllText(final_d, doc.DocumentElement.InnerText);
                //XmlTextWriter xml=new XmlTextWriter(
                Console.WriteLine(soapResult);
                //Console.ReadKey();
            }
        }
    }
}
