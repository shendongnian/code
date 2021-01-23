    // Set up the content-disposition header with proper encoding of the filename
    var contentDisposition = new ContentDispositionHeaderValue("attachment");
    contentDisposition.SetHttpFileName("FileDownloadName.ext");
    Response.Headers[HeaderNames.ContentDisposition] = contentDisposition.ToString();
    // Return the actual filestream
    return new FileStreamResult(@"path\to\file", "content/type");
