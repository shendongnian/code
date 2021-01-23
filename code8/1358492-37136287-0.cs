            try
            {
                string url = "http://myfirsturl.com";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "application/xml"; // <== THIS FIXED IT
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        XDocument doc = XDocument.Load(stream);
                        Console.WriteLine(doc);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
