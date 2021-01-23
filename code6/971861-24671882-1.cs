    public static System.Drawing.Image GetVisitorImage(NetworkInfo networkInfo, string partnerId, string deviceId, string visitorId)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(networkInfo.baseUrl + "GetVisitorImage" + "/" + visitorId);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "" + networkInfo.userName + "|" + networkInfo.userPassword + "");
            httpWebRequest.Headers.Add("PartnerId", partnerId);
            httpWebRequest.Headers.Add("DeviceId", deviceId);
            httpWebRequest.Proxy = ConfigureProxy(networkInfo);
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                result = result.Remove(0, 1); // remove first character
                result = result.Remove(result.Length - 1); // remove last character
                byte[] imageBytes = Convert.FromBase64String(result);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
