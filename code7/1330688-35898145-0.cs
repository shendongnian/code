    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) {
        // log request.Method & request.RequestUri
        var response = await base.SendAsync(request, cancellationToken);
        // log first 100 chars of response.Content
        var N = 100;
        var first_100_Chars = await ReadFirstNCharsOfHttpContent(response.Content, N);
        return response;
    }
   
    private static async Task<string> ReadFirstNCharsOfHttpContent(HttpContent httpContent, int N = 100) {
        //get the content Stream
        var contentStream = await httpContent.ReadAsStreamAsync().ConfigureAwait(false);
        //How big is it
        var streamLength = contentStream.Length;
        // Get the size of the buffer to be read
        var bufferSize = (int)(streamLength > N ? N : (N > streamLength ? streamLength : N));
        var ms = new System.IO.MemoryStream(bufferSize);
        //copy only the needed length
        await contentStream.CopyToAsync(ms, bufferSize);
        // The StreamReader will read from the current 
        // position of the MemoryStream which is currently 
        // set at the end of the data we just copied to it.
        // We need to set the position to 0 in order to read 
        // from the beginning.
        ms.Position = 0;
        //reset content position just to be safe.
        contentStream.Position = 0;
        var sr = new System.IO.StreamReader(ms);
        var logString = sr.ReadToEnd();
        return logString;
    }
