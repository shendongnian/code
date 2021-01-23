                 WebRequest request = WebRequest.Create(Form1.patcherBaseURL + "/patcher.ver");
                 WebResponse response = request.GetResponse();
                 Stream data = response.GetResponseStream();
                 string html = String.Empty;
                 using (StreamReader sr = new StreamReader(data))
                 {
                     html = sr.ReadToEnd();
                     var dic = html.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                         .Where(k => !k.StartsWith("#"))
                         .Select(l => l.Split(new[] { '=' }))
                         .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
                     string PatchVerStrServer = dic["PATCHER_VERSION_STRING_SERVER"];
                }
