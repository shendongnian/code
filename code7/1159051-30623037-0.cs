    class Program
    {
       static void Main(string[] args)
       {
           SqlConnection conn = new SqlConnection("server= XXXXX; database = ES1Archive; Integrated Security=false; User ID = sa; Password=XXXXXX");
           conn.Open();
           SqlCommand cmd = new SqlCommand("select * from ServerInfo  where ServerID = 1991638835", conn);
    
           SqlDataReader reader = cmd.ExecuteReader ();
           while (reader.Read())
           {
           		IDataRecord row = (IDataRecord)reader;
    			for(int i = 0; i<row.FieldCount;i++)
    			{
    				Console.WriteLine(row[i]);
    			}
           }
           reader.Close();
           conn.Close();
    
           if (Debugger.IsAttached)
           {
               Console.ReadLine(); 
           }
    
     }
    }
