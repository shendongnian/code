            //GET
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://160.114.10.17:85/api/Inventory/GetProcessDataByProcessName?deviceCode=OvCHY1ySowF4T2bb8HdcYA==&processName=Main Plant");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json; charset=utf-8";
            //get responce
            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                //read
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    using (StreamReader re = new StreamReader(stream))
                    {
                        String jsonResponce = re.ReadToEnd();
                    }
                }
            }
