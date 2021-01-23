        using (var con = new SqlConnection("Data Source=NIFAL;Initial Catalog=Currency;Integrated Security=True;"))
        {
            con.Open();
            foreach (var Row in dataGridView1.Rows)
            {
                var cmd = new SqlCommand("INSERT INTO CurrencyTable(Country, Currency, Rate) VALUES(@country, @currency, @rate)",con);
                cmd.Parameters.Add(new SqlParameter("@country", SqlDbType.NVarChar, 50) { Value = Row.Cells[0].Value.ToString() });
                cmd.Parameters.Add(new SqlParameter("@currency", SqlDbType.NVarChar, 50) { Value = Row.Cells[1].Value.ToString() });
                cmd.Parameters.Add(new SqlParameter("@rate", SqlDbType.Money, 50) { Value = Row.Cells[2].Value.ToString() });
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Trace.TraceError("Failed to insert line, due to " + err.Message);
                }
            }
        }
