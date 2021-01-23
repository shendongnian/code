            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                queryString = "SELECT COUNT(*) FROM wgcdoccab WHERE serie ='1' and tipodoc ='FSS'  and contribuinte ='999999990' and  datadoc = CONVERT(varchar(10),(dateadd(dd, -1, getdate())),120) ";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    int count = Convert.ToInt32( command.ExecuteScalar());
                    if (count > 0)
                    {
                        check = true;
                        numerador=numerador-1;
                    }
                    else
                    {
                        check = false;
                        MessageBox.Show("Dados Apagados com sucesso");
                    }
                    command.Connection.Close();
                }
            }
