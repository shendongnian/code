    public class FileFormatter : MediaTypeFormatter
    {
        public FileFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }
    
        public override bool CanReadType(Type type)
        {
            return typeof(ImageContentList).IsAssignableFrom(type);
        }
    
        public override bool CanWriteType(Type type)
        {
            return false;
        }
    
        public async override Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger logger)
        {
            if (!content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
    
            var provider = new MultipartMemoryStreamProvider();
            var formData = await content.ReadAsMultipartAsync(provider);
    
            var imageContent = formData.Contents
                .Where(c => SupportedMediaTypes.Contains(c.Headers.ContentType))
                .Select(i => ReadContent(i).Result)
                .ToList();
    
            var jsonContent = formData.Contents
                .Where(c => !SupportedMediaTypes.Contains(c.Headers.ContentType))
                .Select(j => ReadJson(j).Result)
                .ToDictionary(x => x.Key, x => x.Value);
    
            var json = JsonConvert.SerializeObject(jsonContent);
            var model = JsonConvert.DeserializeObject(json, type) as ImageContentList;
    
            if (model == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
    
            model.Images = imageContent;
            return model; 
        }
    
        private async Task<ImageContent> ReadContent(HttpContent content)
        {
            var data = await content.ReadAsByteArrayAsync();
            return new ImageContent
            {
                Content = data,
                ContentType = content.Headers.ContentType.MediaType,
                Name = content.Headers.ContentDisposition.FileName
            };
        }
    
        private async Task<KeyValuePair<string, object>> ReadJson(HttpContent content)
        {
            var name = content.Headers.ContentDisposition.Name.Replace("\"", string.Empty);
            var value = await content.ReadAsStringAsync();
    
            if (value.ToLower() == "null")
                value = null;
    
            return new KeyValuePair<string, object>(name, value);
        }
    }
