	namespace MyProject.Properties									
	{									
		internal class Singleton								
		{								
										
			// Create an instance of the class itself.							
			private static Singleton instance = new Singleton();							
										
			// Wrap the instance in a public property.							
			public static Singleton Instance							
	    	{							
	        	get {return instance;}						
	    	}							
										
			// Prevent additional references from being created with a private constructor.							
			private Singleton() { }							
										
			// Create a non-static variable.    							
			public string nonStatic = "non static";							
										
		}								
	}									
										
