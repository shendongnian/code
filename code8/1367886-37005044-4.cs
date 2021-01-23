    // Define your list of people
    var people = new List<Person>();
    // Create your connection
    using(var connection = new OleDbConnection("{your-connection-string}"))
    {
         try 
         {
             // Define your query (and parameters)
             var query = "SELECT matricule, name, department, specialty, session FROM Table1 WHERE matricule = ?";
             // Define a using statement
             using(var command = new OleDbCommand(query, connection))
             {
                 connection.Open();
                 // Set your parameter prior to executing the query
                 command.Parameters.AddWithValue("@matricule",textBox6.Text);
                 // Execute your query
                 using(var reader = command.ExecuteReader())
                 {
                      // While you have rows, read them
                      while(reader.Read())
                      {
                           people.Add(new Person()
                           {
                               Matricule = reader["matricule"],
                               Name = reader["name"],
                               Department = reader["department"],
                               Specialty = reader["specialty"],   
                          });
                      }
                      // Return your collection
                      return people;
                 }
             }
        }
        catch(Exception ex)
        {
             // Something blew up, handle accordingly
        }
    }
