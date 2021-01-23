    private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            var connString = (@"Data Source=Grupe.sdf");
            if (!File.Exists("Grupe.sdf"))
            {
                SqlCeEngine engine = new SqlCeEngine(connString);
                engine.CreateDatabase();
            }
            using (var conn = new SqlCeConnection(connString))
            {
                try
                {
                    conn.Open();
                    var query = "CREATE TABLE " + textBox1.Text.Trim() + "(" + "Id int NOT NULL IDENTITY (1,1) PRIMARY KEY";
                    MessageBox.Show(query);
                    foreach (Control c in this.Controls)
                    {
                        if (c.Name.Contains("temp") && c is TextBox)
                        {
                            if (!String.IsNullOrEmpty(c.Text))
                            {
                                query += "," + c.Text.Trim() + " ntext NULL";
                                count++;
                            }
                        }
                    }
                    query += ")";
                    MessageBox.Show(query);
                    var command = new SqlCeCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
