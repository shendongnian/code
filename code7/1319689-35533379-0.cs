    private void cbSearchByName_SelectedIndexChanged(object sender,EventArgs e)
    {
        try
        {
            //int RowsAffected = 0;
            DataAccess oDataAccess = new DataAccess();
            con.Open();
            //showing flat number of selected member by name
            oDataAccess.cmd.CommandText = "SELECT Name,City FROM MemberInfo where MemberName='" + cbSearchByName.Text + "'";
            oDataAccess.cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            tbOwnerName.Text = dr["Name"].ToString();
            tbOwnerCity.Text = dr["City"].ToString();
            //similarly store other column values in respective text boxes or wherever you need to get it displayed.
        }
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
