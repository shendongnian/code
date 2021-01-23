	public interface IClass{
		string ClassName {get;set;}
		bool IsValid {get;set;}
	}
	public interface IClassExt:IClass{
		string SuperiorClassName {get;set;}
	}
	public class Foo: IClass{
		public string ClassName {get;set;}
		public bool IsValid {get;set;}
	}
	public class Bar: IClassExt{
		public string ClassName {get;set;}
		public bool IsValid {get;set;}
		public string SuperiorClassName {get;set;}	
	}
