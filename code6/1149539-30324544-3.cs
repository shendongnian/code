	public class Message
	{
		public string Type{get; set;}
		
		public Detail Details {get; set;}
		
		public Context Context {get; set;}
		
		public string Receiver{get;set;}
	}
	
	public class Detail
	{
		public string Locale{get;set;}
		public string MessageType{get;set;}
	}
	
	public class Context
	{
		public List<Parameter> Parameters {get;set;}
		
		public Context()
		{
			Parameters =  new List<Parameter>();
		}
	}	
	
	public class Parameter
	{	
		public string Name {get;set;}
		
		public string Value {get;set;}
	}
	
