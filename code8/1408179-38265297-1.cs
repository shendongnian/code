     SqlConnection con;
                    SqlDataReader reader;
    connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
    con = new SqlConnection(connetionString);
                    try
                    {
                        int id;
                        con.Open();
                        Console.WriteLine("Connection Open ! ");
                        cnn.Close(); 
                    } 
                    catch (Exception ex) { Console.WriteLine("Can not open connection ! "); }
