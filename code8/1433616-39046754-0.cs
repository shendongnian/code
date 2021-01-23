	public class SomeController {
		public void Write()
		{	
			var objectToSerialize = new OutgoingEnvelope<SomeDocument>()	
			{	
				Documents = new List<SomeDocument>() {new SomeDocument() {Name = "Hi"}},	
				TypeId = "Some type"	
			};
			var json = JsonConvert.SerializeObject(objectToSerialize);
			// var myType = Type.GetType(typeName);	
			var myType = typeof(OutgoingEnvelope<SomeDocument>);	
			var fromJsonString = JsonConvert.DeserializeObject(json, myType) as IOutgoingEnvelope<IDocumentType>;	
			
			if(fromJsonString == null)	
				throw new NullReferenceException();	
		}	
	}
    public interface IDocumentType
    {
        string Name { get; set; }
        // known common members in the interface
    }
    public class SomeDocument : IDocumentType
    {
        public string Name { get; set; }
    }
    public interface IOutgoingEnvelope<T> where T : IDocumentType
    {
        string TypeId { get; set; }
        IEnumerable<T> Documents { get; }
    }
    public class OutgoingEnvelope<T> : IOutgoingEnvelope<T> where T : IDocumentType
    {
        public string TypeId { get; set; }
        public OutgoingEnvelope()
        {
            Documents = new List<T>();
        }
        public IEnumerable<T> Documents { get; set; }
    }
