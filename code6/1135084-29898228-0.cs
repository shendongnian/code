Assuming that you're using the HttpClient class to make your request, You can use the HttpResponseMessage that your query returns to decide if you want to download the file or not.  For example:
HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("http://MySite/my/download/path").ConfigureAwait(false);
if (!String.Equals(response.Content.Headers.ContentDisposition.DispositionType, "attachment", StringComparison.OrdinalIgnoreCase)) {
  return;
}
// Call some method that will check if the file extension and/or media type 
// of the file are acceptable.
if (!IsAllowedDownload(response.Content.Headers.ContentDisposition.FileName, response.Content.Headers.ContentType.MediaType)) {
  return;
}
// Call some method that will take a stream containing the response payload 
// and write it somewhere.
WriteResponseStream(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
