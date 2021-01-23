    StringBuilder strsql = new StringBuilder("INSERT INTO TeseI ");
    foreach (var row in DataGridView.Rows)
    {
        strsql.AppendFormat(" SELECT '{0}', '{1}' UNION ALL ", row.Cells["Emp_name"].Value, row.Cells["Emp_number"].Value);
    }
    // remove the last 'UNION ALL '
    strsql.Remove(strsql.Length - 10, 10);
    string constring = @"Data Source=WINCTRL-RDJN6O6;Initial Catalog=Care_AlexDemo;Integrated Security=True";
    using (SqlConnection con = new SqlConnection(constring))
    {
        using (SqlCommand cmd = new SqlCommand(strsql.ToString(), con))
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    MessageBox.Show("Records inserted.");
