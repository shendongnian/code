    WebRequest request = WebRequest.Create(Form1.patcherBaseURL + "/patcher.ver");
    WebResponse response = request.GetResponse();
    Stream data = response.GetResponseStream();
    string html = String.Empty;
    using (StreamReader sr = new StreamReader(data))
    {
        html = sr.ReadToEnd();
        var dic = html
            .Split (new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Where (line => !line.StartsWith("#"))        // Skip commented out lines
            .Select(line => line.Split(new[] { '=' }, 2)) // Beware: some values have spaces
            .ToDictionary(token => token[0].Trim(), token => token[1].Trim());
        string patchVerStrServer = dic["PATCHER_VERSION_STRING_SERVER"];
    }
