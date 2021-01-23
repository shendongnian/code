    public int GetScalarValue()
            {
                int result = 0;
                using (SqlConnection cn = new SqlConnection("CONECTION_STRING"))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("select count(*) from login where username=@login and password=@password")) {
                        cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = Username.Text;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password.Text;
                        result = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
                return result;
            }
