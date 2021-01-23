    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        var drv = DgEmp.SelectedItem as DataRowView;
        if (drv == null) return;
        var empNo = drv[1].ToString(); //getting empno column
        try
        {
            using (var con = new SqlConnection(_conString)) //my connection
            {
                var sqlqry = "delete dbo.Employee where EmpNo='"+empNo+"'";
                con.Open();
                var cmd = new SqlCommand(sqlqry, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridBind(); //Binding grid after delete
                MessageBox.Show("Data deleted successfully");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
