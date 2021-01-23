    // Create a WebRequest to the remote site
    WebRequest myWebClient = WebRequest.Create(uri);
    myWebClient.ContentType = "application/xml";
    myWebClient.Method = method;
    // Apply ASCII Encoding to obtain the string as a byte array.
    string postData = //Data you want to post;
    byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(postData);
    Stream dataStream = myWebClient.GetRequestStream();
    dataStream.Write(byteArray, 0, byteArray.Length);
    dataStream.Close();
                
    // Call the remote site, and parse the data in a response object
    System.Net.WebResponse response = myWebClient.GetResponse();
    // Check if the response is OK (status code 200)
    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //{
    // Parse the contents from the response to a stream object
    System.IO.Stream stream = response.GetResponseStream();
    // Create a reader for the stream object
    System.IO.StreamReader reader = new System.IO.StreamReader(stream);
    // Read from the stream object using the reader, put the contents in a string
    string contents = reader.ReadToEnd();
