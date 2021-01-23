    public List<Movie> Movies{ get; set; }
    public void Connect()
            {
             string cs = "Data Source=" + Environment.CurrentDirectory + "\\example.db";
                using (var connection = new SQLiteConnection(cs))
                {
                    
                    var listOfMovies= new List<Movie>();
                    var stm = "SELECT * FROM Movie";
                    var command = new SQLiteCommand(stm , connection);
                    try
                    {
                       
                        var reader = command.ExecuteReader();
                     
                        while (reader.Read())
                        {
                           
                            listOfMovies.Add(new Movie
                            {
                                
                                MovieID= int.Parse(reader["EmployeeId"].ToString()),
                                Title= reader["Title"].ToString(),
                                Rating= reader["Rating"].ToString(),
                                //Do what ever you should be doing with the image.
    
                            });
                        }                      
                        reader.Close();                  
                        Movies = listOfMovies;
                    }
                        
                    catch (Exception ex)
                    {
                        throw;
                    }
    
                }
    
            }
    public class Movie
    {
    Public int MovieID {get;set;}
    Public String Title {get;set;}
    Public int rating {get;set;}
    Public Byte Image {get;set;}
    }
