    [ServiceContract]
    public interface IStreamingService
    {
        [OperationContract]
        [WebGet(BodyStyle=WebMessageBodyStyle.Bare, UriTemplate = "/video?id={id}")]
        Stream GetVideo(string id);
    }
    
    public class StreamingService : IStreamingService
    {
        public System.IO.Stream GetVideo(string id)
        {
            Stream stream = File.OpenRead("c:\\Temp\\Video.mp4");
            //WriteResponseHeaders(stuff);
            return stream;
        }
    }
