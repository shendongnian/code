            private void PullFromQuandl()
           {
            QuandlDownloadRequest request = new QuandlDownloadRequest();
            request.APIKey = "Mi1xP1q2776TU4kmGcHo";
            request.Datacode = new Datacode("CURRFX", "EURUSD");
            request.Format = FileFormats.JSON;
            request.Frequency = Frequencies.Monthly;
            request.Truncation = 100;
            request.Sort = SortOrders.Ascending;
            string jsonString = request.ToRequestString();
            HttpWebRequest request2 = null;
            HttpWebResponse response = null;
            string returnData = string.Empty;
            request2 = (HttpWebRequest)System.Net.WebRequest.Create(new Uri(jsonString));
            request2.Method = "GET";
            response = (HttpWebResponse)request2.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            returnData = reader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<RootObject>(returnData);
            dgvPending.DataSource = result;
            }
