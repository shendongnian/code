    Parallel.ForEach(privatedictionary, (dataToPost) =>
            {
                HttpWebRequest wbrq = (HttpWebRequest)WebRequest.Create("www.sitetohit.com");
                {
                    using (StreamWriter sw = new StreamWriter(wbrq.GetRequestStream()))
                    {
                        sw.Write(dataToPost);
                    }
                }
            });
