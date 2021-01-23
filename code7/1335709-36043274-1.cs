    // using System.Data.SqlClient; // no using statement
    
    namespace MyNamespace {
    	public class MyClass {
    		public void TestMethod(){
    			// SqlConnection myConnection = null; // this line would not compile if you remove the comment because the compiler cannot find a global type SqlConnection 
    			System.Data.SqlClient.SqlConnection myConnection2 = null; // you need a namespace because there is no using statement at the top so no shortcuts
    		}
    	}
    }
