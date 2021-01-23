    [ComVisible(true)]
    public class MyClass {
    
    
    [ComVisible(true)]
    public OracleConnection GetConnection(){
    
       var connectString = "Data Source=MYDSNNAME;User ID=strong_ID; Password=strong_PWD";
       var con = new Oracle.DataAccess.Client.OracleConnection(connectString);
       con.Open();
       return con;
    }
    
    }
