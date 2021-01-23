    String sql = @"select * from refAnomalie";
            List<refAnomalie> listeRefference = new List<refAnomalie>();
            var con =  new SqlConnection("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=Banque;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            using (var command= new SqlCommand(sql,con)){
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        listeRefference.Add(new refAnomalie
                        {
                            code_anomalie = reader.GetInt32(0),
                            libelle_anomalie = reader.GetString(1),
                            score_anomalie = reader.GetInt32(2),
                            classe_anomalie = reader.GetString(3)
                        });
                        }
            }
