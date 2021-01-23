            var xmlString = string.Empty;
            var xmlPath = "pathToFile.xml";
            if (File.Exists(xmlPath))
            {
                xmlString = File.ReadAllText(xmlPath);
            }
            var xmlBytes = System.Text.Encoding.ASCII.GetBytes(xmlString);
            var url = "http://data.com:7000";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = xmlBytes.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(xmlBytes, 0, xmlBytes.Length);
            requestStream.Close();
            var response = (HttpWebResponse)request.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
            var result = streamReader.ReadToEnd(); // the respond is in here!
            result.Close();
            response.Close();
