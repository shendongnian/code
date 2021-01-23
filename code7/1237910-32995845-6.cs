    #define UseAlternateGreeting
    public class MyClass
    {
        public string GetGreeting()
        {
            #if defined UseAlternateGreeting
                return "Hello World!";
            #else
                return "Here I am!";
            #endif
        }
    }
    
