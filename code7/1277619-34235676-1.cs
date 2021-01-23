    void Main()
    {
        MenuNavigator navigator = new MenuNavigator();
        
        Navigation methodNextAttribute = navigator.GetType()
                                                  .GetMethod("Next")
                                                  .GetCustomAttribute<Navigation>();
                                
        Console.WriteLine ("Method `Next` has the `Navigation` attribute?\n> {0}\n", methodNextAttribute != null);
        // -------- Output -------- 
        // Method `Next` has the `Navigation` attribute?
        // > True
        
        Navigation methodLastAttribute = navigator.GetType()
                                                  .GetMethod("Last")
                                                  .GetCustomAttribute<Navigation>();
        
        Console.WriteLine ("Method `Last` has the `Navigation` attribute?\n > {0}\n", methodLastAttribute != null);  
        // -------- Output -------- 
        // Method `Last` has the `Navigation` attribute?
        // > False
    }
    
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class Navigation : Attribute
    {
    }
    
    public class MenuNavigator
    {
        [Navigation]
        public void Next()
        {
        }
    
        public void Last(bool bla)
        {
        }
    }
