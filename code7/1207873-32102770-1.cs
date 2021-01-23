    public void webTest()
    {
        WebRequest request = WebRequest.Create("http://xxx.staging97.com/apixxx@gmail.com/123456/469-Course_36VYS75T-11-1440001458_VFC-V6.3.cbook/teacher/");
        request.Method = "GET";
        WebResponse ws = request.GetResponse();
        string jsonString = string.Empty;
        using (System.IO.StreamReader sreader = new System.IO.StreamReader(ws.GetResponseStream()))
        {
            jsonString = sreader.ReadToEnd();
        }
    }
