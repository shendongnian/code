     public DataSet ExecutarDataSet(string str_sql)
                {
                    SqlConnection Conn = new SqlConnection(); // Faz Conexão;
                    SqlCommand cmdComando = new SqlCommand(); // Recebe o comando.
                    SqlDataAdapter DataAdt = new SqlDataAdapter(); // Preenche o DataTable.
                    DataSet DS = new DataSet();
        
                    try
                    {
                        Conn = AbrirBanco();
                        cmdComando.CommandText = str_sql;
                        cmdComando.CommandType = CommandType.Text;
                        cmdComando.Connection = Conn;
        
                        DataAdt.SelectCommand = cmdComando;
                        DataAdt.Fill(DS); // Preenche a Datatable
        
                        return (DS);
                    }
        
                    catch (Exception Erro)
                    { throw Erro; }
        
                    finally
                    { Conn.Close(); }
                }
