    public class AddUiToolsFilter : MemoryStream
    {
        private readonly Stream _response;
        private readonly string _htmlToAppend;
        public AddUiToolsFilter(Stream response, string htmlToAppend)
        {
            _response = response;
            _htmlToAppend = htmlToAppend;
        }
        public override void Close()
        {
            var html = Encoding.UTF8.GetString(base.ToArray());
            // Add your UI Tools
            string newHtmlDocument = html.Replace("</body>", _htmlToAppend + "</body>");
            byte[] rawResult = Encoding.UTF8.GetBytes(newHtmlDocument);
            _response.Write(rawResult, 0, rawResult.Length);
            _response.Close();
        }
    }
