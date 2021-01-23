    private static void SendImageSet(ImageSet imageSet)
{
    var multipartContent = new MultipartFormDataContent();
    var imageSetJson = JsonConvert.SerializeObject(imageSet, 
        new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    multipartContent.Add(
        new StringContent(imageSetJson, Encoding.UTF8, "application/json"), 
        "imageset"
        );
    int counter = 0;
    foreach (var image in imageSet.Images)
    {
        var imageContent = new ByteArrayContent(image.ImageData);
        imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
        multipartContent.Add(imageContent, "image" + counter++, image.FileName);
    }
    var response = new HttpClient()
        .PostAsync("http://localhost:53908/api/send", multipartContent)
        .Result;
    var responseContent = response.Content.ReadAsStringAsync().Result;
    Trace.Write(responseContent);
