    public static T MakeRequestAttachmentId<T>(string requestUrl, string strToken) where T : object
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Headers["Authorization"] = "OAuth " + strToken;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    var jsonResponse = (T)objResponse;
                    response.Close();
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return default(T);
            }
        }
