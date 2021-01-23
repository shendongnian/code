    // our first, base class. put this in it's own project.
    namespace SecondLevel
    {
        public class SecondLevel
        {
            public void DoSomething()
            {
    
            }
        }
    }
    
    
    // our second class that references the base class. Add this to it's own project as well. 
    namespace FirstLevel
    {
        public class FirstLevel
        {
            public SecondLevel.SecondLevel reference;
    
            public FirstLevel()
            {
                reference = new SecondLevel.SecondLevel();
            }
    		
    		public void DoSomethingWithReferencedClass()
    		{
    			reference.DoSomething();
    		}
        }
    }
    
    
    // our "Client" console app that does nothing, but indicates the compiler errors.
    // also in it's own project	
    // Reference the project that "FirstLevel" is in, 
    // but not the one that "Second Level" is in. 
    namespace ConsoleTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var primary = new FirstLevel.FirstLevel();
                
    			primary.reference.DoSomething(); // will cause compiler error telling you to reference "Second Level"
    
    			primary.DoSomethingWithReferencedClass(); // no compiler error: does the same thing the right way.
            }
        }
    }
