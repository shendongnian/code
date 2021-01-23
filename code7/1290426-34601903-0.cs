    // Send an HTTP message instead of a string.
    public HttpResponseMessage Get(string unit, string begindate)
    {
        // Here you process the data...
        return new HttpResponseMessage()
        {
            Content = new StringContent(
                String.Format("{0}<br/><br/>{1}", summaryHtmlFromFile, detailHtmlFromFile), 
                Encoding.UTF8, 
                "text/html"
            )
        };
    }
