    using System.Data.SqlClient;
    
    namespace MyNamespace {
    	public class MyClass {
    		public void TestMethod(){
    			SqlConnection myConnection = null; // no need for a namespace prefix
    			System.Data.SqlClient.SqlConnection myConnection2 = null; // this is ok too, the namespace is redundant but that is fine
    		}
    	}
    }
