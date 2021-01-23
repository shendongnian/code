            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                queryString = "SELECT MIN(ISNULL(numdoc,0)) FROM wgcdoccab WHERE serie ='1' and tipodoc ='FSS'  and contribuinte ='999999990' and  datadoc = CONVERT(varchar(10),(dateadd(dd, -1, getdate())),120) ";
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    int num= Convert.ToInt32( command.ExecuteScalar());
                    if (num> 0)
                    {
                        check = true;
                        numerador=num;
                    }
                    else
                    {
                        check = false;
                        MessageBox.Show("Dados Apagados com sucesso");
                    }
                    command.Connection.Close();
                }
            }
