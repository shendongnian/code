    public void AddCustomHeaders(WebClient web, string headers)
        {
            List<string> listOfHeaders = new List<string>();
            listOfHeaders = headers.Split('\n').ToList();
            foreach (var header in listOfHeaders)
                web.Headers.Add(header);
        }
