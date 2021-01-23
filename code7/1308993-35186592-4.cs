    Parallel.ForEach(privatedictionary, (onetwo) =>
            {
                var dataToPost = onetwo.Key + "=" + Server.UrlEncode(onetwo.Value) + "&";
                HttpWebRequest wbrq = (HttpWebRequest)WebRequest.Create("www.sitetohit.com");
                {
                    using (StreamWriter sw = new StreamWriter(wbrq.GetRequestStream()))
                    {
                        sw.Write(dataToPost);
                    }
                }
            });
