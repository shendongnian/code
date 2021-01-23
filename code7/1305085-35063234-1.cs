    sSQL = "Select * From tbl_TripPrefixDestination Where Country = @Country";
    ...
    SqlParameter param = new SqlParameter("@Country", ddlCountrySelect.SelectedItem.Text);
    SqlCommand cmd = new SqlCommand(sSQL, conn);
    cmd.Parameters.Add(param);
