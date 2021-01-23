    try
            {
                huella.Open();
                OleDbCommand comando = new OleDbCommand();
                comando.Connection = huella;
                string consulta = "select [User].IdUser,[User].IdentificationNumber,[User].name,[Record].RecordTime," +
                    "[Record].RecordType from [User] inner join [Record] on [User].IdUser = [Record].IdUser " +
                    
                "where " + "[Record].IdUser=@01 and [Record].RecordTime between @time1 and @time2 order by [User].IdUser asc,[Record].RecordTime asc";
                comando.CommandText = consulta;
                comando.Parameters.AddWithValue("@01", IDcm.Text.ToString());
                comando.Parameters.AddWithValue("@time1", dateTimePicker1.Value.Date);
                comando.Parameters.AddWithValue("@time2", dateTimePicker2.Value.Date);
                OleDbDataAdapter datos = new OleDbDataAdapter(comando);
                // using( OleDbDataReader lector = comando.ExecuteReader())
                tabla = new DataTable();
                datos.Fill(tabla);
                //MessageBox.Show(""+tabla);
                clu.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex);
            }
            finally
            {
                huella.Close();
            }
