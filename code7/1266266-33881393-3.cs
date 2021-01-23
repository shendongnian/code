    public class CustomMediaTypeFormatter : MediaTypeFormatter
    {
        public CustomMediaTypeFormatter ()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }
            
        public override bool CanReadType(Type type)
        {
            return type == typeof (DogDTO);
        }
    
        public override bool CanWriteType(Type type)
        {
            return false;
        }
    
        public async override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream, 
            HttpContent content, 
            IFormatterLogger formatterLogger)
        {
            var provider = await content.ReadAsMultipartAsync();
    
            var modelContent = provider.Contents
                .FirstOrDefault(c => c.Headers.ContentDisposition.Name.NormalizeName() == "dog");
                
            var dogDTO = await modelContent.ReadAsAsync<DogDTO>();
    
            var fileContent = provider.Contents
                .Where(c => c.Headers.ContentDisposition.Name.NormalizeName() == "image"))
                .FirstOrDefault();
    
            dogDTO.FileAboutDog = await fileContent.ReadAsByteArrayAsync();
          
            return dogDTO;
    
        }
    }
    public static class StringExtensions
    {
        public static string NormalizeName(this string text)
        {
            return text.Replace("\"", "");
        }
    }
