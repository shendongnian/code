    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string cs = "Server=somedb.database.windows.net;Database=somedb;User Id=SomeUser;Password=SomePassword;";
                SqlConnection myConnection = new SqlConnection(cs);
    
                try
                { myConnection.Open(); }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
    
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("SELECT * FROM Table1", myConnection);
                    myReader = myCommand.ExecuteReader();
                    var SomeDataframe = Frame.ReadReader(myReader);
                    SomeDataframe.Print();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
                try
                { myConnection.Close(); }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }
    }
