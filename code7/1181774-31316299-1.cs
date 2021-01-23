    	public class A : A<object>
    	{
    		// non-generic method in non-generic class
    		public static A GetInstance() 
    		{
    			return new A();
    		}
    		
    		// generic method
    		public static A<T> GetInstance<T>() 
    		{
    			return new A<T>();
    		}
    	}
    	
    	public class A<T>
    	{
    		// non-generic method in generic class
    		public static A<T> GetInstance() 
    		{
    			return new A<T>();
    		}
    	}
    }
