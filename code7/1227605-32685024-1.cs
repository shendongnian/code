         using (var con = new SqlConnection("Data Source=NIFAL;Initial Catalog=Currency;Integrated Security=True;"))
            {
                con.Open();
                foreach (var Row in dataGridView1.Rows)
                {
                    var cmd = new SqlCommand("INSERT INTO CurrencyTable(Country, Currency, Rate) VALUES(@country, @currency, @rate)",con);
                    cmd.Parameters.Add("@country", SqlDbType.VarChar, 20).Value = Row.Cells[0].Value.ToString();
                    cmd.Parameters.Add("@currency", SqlDbType.VarChar, 20).Value = Row.Cells[1].Value.ToString();
                    cmd.Parameters.Add("@rate", SqlDbType.Float).Value = Row.Cells[2].Value.ToString();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {
                        //You should here mark the row that has an error and output the error message 
                        Row.Cells[3].Value = err.Message;
                    }
                }
            }
