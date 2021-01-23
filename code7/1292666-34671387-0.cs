    protected void btnSave_Click(object Sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(Utils.Connection);
        SqlCommand cmd = new SqlCommand("citizen_complaints_i", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@TYPE", SqlDbType.VarChar).Value = ddlCType.SelectedValue;
        cmd.Parameters.Add("@SUBTYPE", SqlDbType.VarChar).Value = ddlSubType.SelectedValue;
        cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar).Value = txtLoc.Text;
        cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = txtDesc.Text;
        cmd.Parameters.Add("@IMAGE", SqlDbType.VarChar).Value = Utils.file_upload(fuImage);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //...
        }
        finally
        {
            con.Close();
        }
    }
