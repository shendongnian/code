    protected void insertBttn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            int i = 0;
            int j = 0;
            string query = "";
            string columnText = "";
            string valueText = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                columnText = "";
                valueText = "";
                for (j = 0; j < dataGridView1.Rows[0].Cells.Count; j++)
                {
                    if (j != 0)
                    {
                        columnText += ",";
                        valueText += ",";
                    }
                    columnText += dataGridView1.HeaderRow.Cells[j].Text;
                    valueText += "'" + dataGridView1.Rows[i].Cells[j].Text + "'";   
                }
                query += "insert into " + comboBox1.SelectedValue.ToString() + " (" + columnText + ") values (" + valueText + ")";
            }
   
            try
            {
                cmd.CommandText = query;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }          
        }
