    public class JpegFormatter : MediaTypeFormatter
    {
        public JpegFormatter()
        {
            //this allows a route with extensions like /Users/1.jpg
            this.AddUriPathExtensionMapping(".jpg", "image/jpeg");
            
            //this allows a normal route like /Users/1 and an Accept header of image/jpeg
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
        }
        public override bool CanReadType(Type type)
        {
            //Can this formatter read binary jpg data?
            //answer true or false here
            return false;
        }
        public override bool CanWriteType(Type type)
        {
            //Can this formatter write jpg binary if for the given type?
            //Check the type and answer. You could use the same formatter for many different types.
            return type == typeof(User);
        }
        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            //value will be whatever model was returned from your controller
            //you may need to check data here to know what jpg to get
            var user = value as User;
            if (null == user)
            {
                throw new NotFoundException();
            }
            var stream = SomeMethodToGetYourStream(user);
            await stream.CopyToAsync(writeStream);
        }
    }
