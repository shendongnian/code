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
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ResponseAttachmentIds));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                var jsonResponse = objResponse as T;
                response.Close();
                return jsonResponse;
            }
        }
        catch (Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.Message);
            return null;
        }
    }
