        private void button5_Click(object sender, EventArgs e)
        {
            string MyConnectionString = "Server=localhost; Database=markcreations; Uid=root; Pwd=admin";
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            foreach (DataGridViewRow row in dataGridView1.Rows)                   
            {
             try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = connection.CreateCommand();
                    if (row.IsNewRow) continue;
                    cmd.Parameters.AddWithValue("@invoice", row.Cells["Invoice"].Value);
                    cmd.Parameters.AddWithValue("@jobOrder", row.Cells["jobOrder"].Value);
                    cmd.Parameters.AddWithValue("@dateTime", row.Cells["Date"].Value);
                    cmd.Parameters.AddWithValue("@clientCode", row.Cells["Client Code"].Value);
                    cmd.Parameters.AddWithValue("@clientName", row.Cells["Client Name"].Value);
                    cmd.Parameters.AddWithValue("@jobName", row.Cells["Job Name"].Value);
                    cmd.Parameters.AddWithValue("@flexQuality", row.Cells["Flex Quality"].Value);
                    cmd.Parameters.AddWithValue("@sizeLength", row.Cells["Size Length"].Value);
                    cmd.Parameters.AddWithValue("@sizeWidth", row.Cells["Size Width"].Value);
                    cmd.Parameters.AddWithValue("@rate", row.Cells["Rate"].Value);
                    cmd.CommandText = "INSERT INTO record(invoice, jobOrder, dateTime, clientCode, clientName, jobName, flexQuality, sizeLength, sizeWidth, rate)VALUES(@invoice, @jobOrder, @dateTime, @clientCode, @clientName, @jobName, @flexQuality, @sizeLength, @sizeWidth, @rate)";
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Records inserted.");
        }
