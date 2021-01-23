    protected void Button2_Click(object sender, EventArgs e)
    {
        string sel = DropDownList1.SelectedValue;
        // if your selection is empty, abort early
        if( sel == null || string.IsNullOrEmpty(sel.Text)) return;
        // use a SQL parameter like you did with update
        string query = "DELETE FROM MovieList WHERE Movie=@MovieValue";
        System.Data.OleDb.OleDbCommand ocmd =
             new System.Data.OleDb.OleDbCommand(query,
             new System.Data.OleDb.OleDbConnection(CSTR));
        // here the selected text for the movie is set to the movie parameter
        ocmd.Parameters.AddWithValue("@MovieValue", sel.Text);
        ocmd.Connection.Open();
        ocmd.ExecuteNonQuery();
        ocmd.Connection.Close();
        populateDropDowns();
    }
