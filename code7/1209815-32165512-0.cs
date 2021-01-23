    string content = "Test value"
    
                try
                {
                    var counter = 1;
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("select name from Persons",
                        myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        if (counter == 4)
                        {
                            counter = 1;
                            Console.WriteLine(content);
                        }
                        Console.WriteLine("- " + myReader["name"].ToString());
    
                        counter++;
    
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
