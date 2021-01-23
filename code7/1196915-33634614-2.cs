    if (Request.Headers.Range != null)
    {
        // Return part of the video
        HttpResponseMessage partialResponse = Request.CreateResponse(HttpStatusCode.PartialContent);
        partialResponse.Content = new ByteRangeStreamContent(stream, Request.Headers.Range, mediaType);
        return partialResponse;
    }
    else 
    {
        // Return complete video
        HttpResponseMessage fullResponse = Request.CreateResponse(HttpStatusCode.OK);
        fullResponse.Content = new StreamContent(stream);
        fullResponse.Content.Headers.ContentType = mediaType;
        return fullResponse;
    }
