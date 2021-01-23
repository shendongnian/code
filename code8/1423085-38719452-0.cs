    private string _ejecutarSentencia(string query, SqlConnection cnn)
        {
            string resultado = string.Empty;
            Logica logica = new Logica();
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                resultado += reader["Code"].ToString().Trim() + "\n";
                        }
                    }
                }
            }
            return resultado;
        }
