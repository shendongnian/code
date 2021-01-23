                string connectionString = connectionString = ConfigurationManager.ConnectionStrings["ProjectPractice"].ConnectionString;
              
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmo = new SqlCommand("spBuscaUsuario", con);
                cmo.CommandType = CommandType.StoredProcedure;
                cmo.Parameters.Add("@Username", SqlDbType.Char, 25).Value = txtUsername.Text;
                SqlParameter NroUserName = new SqlParameter("@Num_de_Usuarios", 0);
                NroUserName.Direction = ParameterDirection.Output;
                cmo.Parameters.Add(NroUserName);
                con.Open();
                cmo.ExecuteNonQuery();
                int contarUsername = Int32.Parse(cmo.Parameters["@Num_de_Usuarios"].Value.ToString());
