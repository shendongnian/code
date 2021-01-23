    public class Credentials {
    	private static Credentials instance;
    	
    	private Credentials() {}
    	
    	public static Credentials getInstance() {
            if (instance == null)
    			instance = new Credentials();
    		return instance;
    	}
    	
    	public string Val {get; private set;}
    	
        public void method1()
        {
            Val ="abc";
        }
        
        public void method2()
        {
            if(Val =="abc") {
                Console.WriteLine(Val);
            }
    		else {
    			Console.WriteLine("Val is not set");
    		}
        }
    }
