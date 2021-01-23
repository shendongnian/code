    postResponse = (HttpWebResponse)postReq.GetResponse();
    Stream Reader = postResponse.GetResponseStream();
    byte[] Data = new byte[postResponse.ContentLength];
    Reader.Read(Data, 0, Data.Length);
    Data = Decompress(Data);
    string Result = System.Text.Encoding.UTF8.GetString(Data);
    MessageBox.Show(Result);
