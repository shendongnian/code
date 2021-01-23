        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=tempdb;Integrated Security=True");
            SqlCommand cmd1 = new SqlCommand("create table ##gridtemp (itmcod varchar(MAX))", conn1);
            conn1.Open();
            cmd1.ExecuteNonQuery();
            DataTable dts = new DataTable();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn1);
            bulkCopy.DestinationTableName = "##gridtemp";
            bulkCopy.WriteToServer(dts);
            conn1.Close();
            
            int i = 0;
            List<int> ChkedRow = new List<int>();
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Column1"].Value) == true)
                {
                    ChkedRow.Add(i);
                }
            }
            if (ChkedRow.Count == 0)
            {
                MessageBox.Show("Select Items to view report");
                return;
            }
            foreach (int j in ChkedRow)
            {
                String ConnectionString1 = @"Data Source=.\SQLEXPRESS;Initial Catalog=tempdb;Integrated Security=True;Pooling=False";
                cnnStr = @"INSERT INTO ##gridtemp (itmcod)
                            VALUES ('" + dataGridView1.Rows[j].Cells["itmcod"].Value.ToString() + "');";
                try
                {
                    using (SqlConnection cs = new SqlConnection(ConnectionString1))
                    {
                        using (cmd = new SqlCommand(cnnStr, cs))
                        {
                            cs.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("Records Added Succesfully");
        }
    }
