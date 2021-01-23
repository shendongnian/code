    public class ConstructpptxController : ApiController
    {
        public static List<byte> Document { get; set; } = new List<byte>();
        public string Post([FromBody]ConstructpptxPayload payload)
        {
            if (payload.counter == 0)
                Document.Clear();
            var payloadData = Convert.FromBase64String(payload.documentData);
            var pptBytes = Encoding.UTF8.GetString(payloadData).Split(',').Select(byte.Parse).ToArray();
            Document.AddRange(pptBytes);
            if(payload.isLastSlice)
            {
                var path = @"C:/Some/Local/Path/Presentation.pptx";                
                var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(Document.ToArray(), 0, Document.Count());
                fileStream.Close();
                Document.Clear();
            }
            return $"Counter: {payload.counter}, isLast: {payload.isLastSlice}, docLength: {Document.Count}";
        }
    } 
    
    public class ConstructpptxPayload
    {
        public bool isLastSlice { get; set; }
        public int counter { get; set; }
        public string documentData { get; set; }
    }
