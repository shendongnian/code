     Uri url = new Uri("http://www.google.com/finance/info?q=NSE%3A" + NameofCompany);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.ContentType = "application/json; charset=utf-8";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    string Responsecontent = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    string CurrentContent = Responsecontent.Replace("//", "").Trim();
                    var v = JsonConvert.DeserializeObject<List<CurrentValue>>(CurrentContent);
