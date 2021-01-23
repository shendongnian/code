    public class ConnectionHandler
    {
        static SqlConnection con=null;
        public static SqlConnection ConnectionObj 
        {
            get
            {
			 if(con==null)
				 con=new SqlConnection("your connection string");
			return con;
		 }
    }
