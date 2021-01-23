        private DataTable LoadRecipe()
        {
           DataTable recipe = new DataTable();
           var connectionString = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True"
            using(var con = new SqlConnection(connectionString){
             con.Open();
              try       
                {
                  //Fetching top recipe     
                    var query = ("SELECT Recipe_ID, Recipe_Name FROM Recipe");
                    var cmd = new SqlCommand(query, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    recipe.Load(dr);
        }
          catch (Exception ex)
               {
                 throw; (or logg)
               }
          finally // ensure that connection would be closed at any case
               {            
                  con.Close();
               }
          }
            return recipe;
            }
