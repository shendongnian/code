    public abstract class Request
    {
        public string Application { get; set; }
        public virtual string MessageAsString()
        {
            return CreateMessage();
        }
        private string CreateMessage()
        {
            return SerializeObject<Request>(this);
        }
        public static string SerializeObject<X>(X toSerialize)
        {
            var xmlSerializer = new XmlArchive(toSerialize.GetType());
            Archive.Provider = CultureInfo.InvariantCulture;
            string utf8 = ""; ;
            using (var  writer = new MemoryStream())
            {
                xmlSerializer.Write(writer, toSerialize);
                writer.Position = 0;
				
				var reader = new StreamReader(writer);
				utf8 = reader.ReadToEnd();
            }
            return utf8;
        }
    }
    public abstract class RequestType1 : Request
    {
        public abstract string RequestType { get; set; }   
        public virtual P_Data DataField { get; set; }
    }
    public abstract class RequestType2 : Request
    {        
        public abstract string RequestType { get; set; }
        public string Sender { get; set; }
    }
    public abstract class RequestType3 : RequestType1
    {
        [Persist("MyNameWhatever")]
        public override P_Data DataField { get; set; }
    }
    public class Payment1 : RequestType1
    {
        public override string RequestType
        {
            get { return "Pay1"; }
            set { }
        }
    }
    public class Payment2 : RequestType2
    {
        public override string RequestType
        {
            get { return "Pay2"; }
            set { }
        }
    }
    public class Payment3 : RequestType3
    {
        public override string RequestType
        {
            get { return "Pay3"; }
            set { }
        }
    }
    public class P_Data
    {
        public P_Data() { TimeStamp = DateTime.Now; }
        public string Language { get; set; }
        public DateTime TimeStamp { get; set; }
    }
