        using System;
        using System.Net.Http;
        using System.Net.Http.Headers;
        private static T PostData<T, P>(P postData, string uri, string path)
        {
            var ret = default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    var response = client.PostAsXmlAsync(path, postData).Result;
                    //var response = client.PostAsJsonAsync(path, postData).Result; if your endpoint accepts json content
                    ret = response.Content.ReadAsAsync<T>().Result;
                }
            }
            catch (Exception ex)
            {
                //Do something
            }
            return ret;
        }
