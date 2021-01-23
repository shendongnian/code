    public class MyFrameworkElement { }
    public class MyTextBox : MyFrameworkElement { }
    
    class Program 
    {    
    		public static Object MyMethod(MyFrameworkElement b) 
            {
    			return new Object();
    		}
    
    		static void Main(string[] args) 
            {
    
    			Func<MyFrameworkElement, Object> f1 = MyMethod;
    			Func<MyTextBox, Object> f2 = f1;
           }
    }
