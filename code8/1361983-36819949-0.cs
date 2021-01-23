        HttpWebRequest httpRequest = (HttpWebRequest)
        WebRequest.Create("http://deviantsmc.com/binary.txt");
        httpRequest.Method = WebRequestMethods.Http.Get;
        HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        Stream httpResponseStream = httpResponse.GetResponseStream();
        using (BinaryReader responseReader = new BinaryReader(httpResponseStream.GetResponseStream()))
        {
            byte[] bytes = responseReader.ReadBytes((int)response.ContentLength);
            using (BinaryWriter sw = new BinaryWriter(File.OpenWrite("tcontent1.txt")))
            {
                sw.Write(bytes);
                sw.Flush();
                sw.Close();
            }
        }
