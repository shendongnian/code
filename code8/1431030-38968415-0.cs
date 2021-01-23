        static void Main(string[] args)
        {
            string url = @"https://api.github.com/";
            string searchString = "url";
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla / 4.0(compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            try
            {
                byte[] dat = wc.DownloadData(url);
                string data = Encoding.ASCII.GetString(dat);
                var values = JObject.Parse(data).Values();
                bool stringFound = values.Any(x => x.Path.Contains(searchString) ||
                                                   x.Value<string>().Contains(searchString)
                                             );
                if(stringFound)
                {
                    Console.WriteLine("JSON contains search string");
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
