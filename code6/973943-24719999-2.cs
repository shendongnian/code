        static void Main(string[] args)
        {
              // Create a new HttpWebRequest object.Make sure that 
              // a default proxy is set if you are behind a firewall.
              HttpWebRequest myHttpWebRequest1 =
                (HttpWebRequest)WebRequest.Create(@"http://content.warframe.com/dynamic/rss.php");
              myHttpWebRequest1.KeepAlive=false;
              // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
              HttpWebResponse myHttpWebResponse1 = 
                (HttpWebResponse)myHttpWebRequest1.GetResponse();
              Console.WriteLine("\nThe HTTP request Headers for the first request are: \n{0}", myHttpWebRequest1.Headers);
              Stream streamResponse = myHttpWebResponse1.GetResponseStream();
              StreamReader streamRead = new StreamReader(streamResponse);
              Char[] readBuff = new Char[256];
              int count = streamRead.Read(readBuff, 0, 256);
              Console.WriteLine("The contents of the Html page are.......\n");
              while (count > 0)
              {
                  String outputData = new String(readBuff, 0, count);
                  Console.Write(outputData);
                  count = streamRead.Read(readBuff, 0, 256);
              }
              Console.WriteLine();
              // Close the Stream object.
              streamResponse.Close();
              streamRead.Close();
              Console.ReadKey();
        }
