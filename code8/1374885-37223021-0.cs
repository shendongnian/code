            try
            {
                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                tRequest.Method = "POST";
                tRequest.ContentType = " application/json;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", apiKey));
                postData =
                  "{ \"collapse_key\":\"score_update\",\"time_to_live\":108,\"delay_while_idle\":true,\"registration_ids\": [ \"" + stringregIds + "\" ], " +
                    "\"data\": {\"time\": " + "\"" + System.DateTime.Now.ToString() + "\", " +
                               "\"message\": \"" + value + "\"}}";
                var bytes = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = bytes.Length;
    
                var stream = tRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
    
                var wResponse = tRequest.GetResponse();
                stream = wResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                var response = reader.ReadToEnd();
    
                var httpResponse = (HttpWebResponse)wResponse;
                var status = httpResponse.StatusCode.ToString();
    
                reader.Close();
                stream.Close();
                wResponse.Close();
    
                //TODO check status
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "sent";
