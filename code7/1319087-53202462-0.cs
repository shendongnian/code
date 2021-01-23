    public static void PostBase64PdfHttpClient(string recordID, string docName, string pdfB64)
        {
            string url = $"baseURL";
            HttpClient client = new HttpClient();
            var myBoundary = "------------ThIs_Is_tHe_bouNdaRY_";
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"UN:PW"));
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{url}/api-endpoint");
            request.Headers.Date = DateTime.UtcNow;
            request.Headers.Add("Accept", "application/json; charset=utf-8");
            MultipartContent mpContent = new MultipartContent("related", myBoundary);
            mpContent.Headers.TryAddWithoutValidation("Content-Type", $"multipart/related; boundary={myBoundary}");
            dynamic jObj = new Newtonsoft.Json.Linq.JObject(); jObj.ID = recordID; jObj.Name = docName;
            var jsonSerializeSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var json = JsonConvert.SerializeObject(jObj, jsonSerializeSettings);
            mpContent.Add(new StringContent(json, Encoding.UTF8, "application/json"));
            mpContent.Add(new StringContent(pdfB64, Encoding.UTF8, "application/pdf"));
            request.Content = mpContent;
            HttpResponseMessage response = client.SendAsync(request).Result;
        }
