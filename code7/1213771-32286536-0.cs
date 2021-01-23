    private void btncartdesign_Click(object sender, EventArgs e)
    {
        string sqlText = @"select * from CartdesignSizes 
                           where cartkey=@txtcartkey";
        DataTable dt = new DataTable();
        using(SqlConnection sql = new SqlConnection(.....))
        using(SqlDataAdapter sd = new SqlDataAdapter(sqlText, sql))
        {
            sd.SelectCommand.Parameters.Add("@txtcartkey", 
                          SqlDbType.NVarChar).Value = txtcartkey.Text;
            sd.Fill(dt);
            dataGridView.DataSource = dt;
            label2.Visible = true;
            label2.Text = dataGridView.Rows.Count.ToString();
        }
    }
