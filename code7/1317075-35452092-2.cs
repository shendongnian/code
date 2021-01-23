      public static object send(string postData, bool isValidate)
            {
                string url = "http://www.google-analytics.com/collect";
                if (isValidate)
                {
                    url = "https://www.google-analytics.com/debug/collect";
                }
    
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(url);
                // Set the Method property of the request to POST.
    
                request.Method = "POST";
    
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                try
                {
                    return JsonConvert.DeserializeObject<ValidateResponse>(responseFromServer);                
                }
                catch (Exception ex)
                {
                    throw new Exception("SendHitFailed",ex);
                }          
            }
