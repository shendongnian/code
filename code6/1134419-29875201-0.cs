                HttpWebResponse res = (HttpWebResponse)httpRequest.GetResponse();
                using (Stream output = File.OpenWrite(@"c:\temp\tmp.html"))
                using (Stream input = res.GetResponseStream())
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                    input.Close();
                    output.Close();
                    string sBuffer = Encoding.UTF8.GetString(buffer);
                    StringReader reader = new StringReader(sBuffer);
    ​
