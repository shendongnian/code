    public class SQLcon
    {
           static SqlConnection konekt = new SqlConnection();
           public SQLcon()
           {
               konekt.ConnectionString = "Data Source=.\\sqlexpress;" +  "Initial Catalog=PRACA;" + "User id=sa;" + "Password=xxXXxx;";
        }
       public void open()
        {
            konekt.Open();
        }
       public void close()
        {
            konekt.Close();
        }
    }
