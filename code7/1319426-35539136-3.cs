    private void RefreshBtn_Click(object sender, EventArgs e)
    {
        try
        {
             SqlConnection connection = new SqlConnection(connString);
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "SELECT * FROM Questions WHERE CategoryID = @CategoryID";
             cmd.Connection = connection;
             cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
             SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
             SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);
             dataAdapter.Update(dataTable);
        }
        catch (Exception)
        {
             MessageBox.Show("ERROR WHILE CONNECTING WITH DATABASE !");
        }
    }
