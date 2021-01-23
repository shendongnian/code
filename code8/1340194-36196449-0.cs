    // Call api
    string apiResultXmlString = ApiGet(requestUrl);
    // Fix api result xml string
    if (!apiResultXmlString.Contains("<?xml"))
        apiResultXmlString = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" + apiResultXmlString;
    // Fix bad response data
    string pattern = "(?<start>>)(?<content>.+?(?<!>))(?<end><)|(?<start>\")(?<content>.+?)(?<end>\")";
    apiResultXmlString = System.Text.RegularExpressions.Regex.Replace(apiResultXmlString, pattern, m =>
                m.Groups["start"].Value +
                System.Web.HttpUtility.HtmlEncode(System.Web.HttpUtility.HtmlDecode(m.Groups["content"].Value)) +
                m.Groups["end"].Value);
