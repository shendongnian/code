    public System.IO.Stream GetVideo(string id)
    {
        RangeHeaderValue rangeHeader;
     
        bool hasRangeHeader = RangeHeaderValue.TryParse(
                    WebOperationContext.Current.IncomingRequest.Headers["Range"], 
                    out rangeHeader);
     
        var response = WebOperationContext.Current.OutgoingResponse;
        Stream stream = File.OpenRead("c:\\Temp\\Video.mp4");
     
        var offset = hasRangeHeader ? rangeHeader.Ranges.First().From.Value : 0;
     
        response.Headers.Add("Accept-Ranges", "bytes");
        response.ContentType = "video/mp4";
     
        if (hasRangeHeader) {
            response.StatusCode = System.Net.HttpStatusCode.PartialContent;
            var totalLength = stream.Length;
            stream = new PartialStream(stream, offset, 10 * 1024 * 1024);
     
     
            var header = new ContentRangeHeaderValue(offset, offset + stream.Length - 1,totalLength);
            response.Headers.Add("Content-Range", header.ToString());
        }
        response.ContentLength = stream.Length;
     
        return stream;
    }
 
