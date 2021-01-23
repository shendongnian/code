    [XmlRoot(ElementName = "Response")]
    public abstract class Response
    {
         public HeaderResponse Header { get; set; }
        public Response()
        {
        }
    }
    [XmlRoot(ElementName = "Response")]
    public class DirectorSearchResponse : Response
    {
        public DirectorSearchResponse() : base()
       {
        /* DO NOTHING */
       }
    } 
