            for (int i = 12; i > 1; i--)
            {
                string folder = string.Format("{0}-{1}", DateTime.Now.Year + "-" + i.ToString().PadLeft(2, '0'));
                string Url1 = "http://www2.epa.gov/sites/production/files/" + folder + "/rindata.csv";
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(Url1, "/rindata.csv");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("404 Error:{0}", Url1));
                }
            }
