	public abstract class Language
	{
		// Field to identify the language by.
		public string Code {get; private set;}
		
		// Contructor that takes language code as parameter
		public Language(string code)
		{
			Code = code;
		}
		
		// Add the strings you want translating.
		// Making them abstract means classes that inherit from
		// this class must provide their own implementation of these strings.
		public abstract string Hello {get;}
		public abstract string Goodbye {get;}
	}
	
