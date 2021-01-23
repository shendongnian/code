       public DataTable ExecuteRequest(string requete)
        {
           
            var dt = new DataTable("Anything"); // this will resolve your problem
            if (requete!= string.Empty)
            {
                using (con = new SqlConnection(ConString))
                {
                   var cmd = new SqlCommand(requete, con);
                   var sda = new SqlDataAdapter(cmd);
                  
                    sda.Fill(dt);
                } 
            }
            return dt;
        }
