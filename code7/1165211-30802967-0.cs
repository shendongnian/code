    protected void MainAccordianRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                try{
                Repeater rep = e.Item.FindControl("childRepeater") as Repeater;
    
    int parentCatId = (int)(Eval("catId"));
    using (SqlConnection con = new SqlConnection(connStr))
    {
        using (SqlCommand cmd = new SqlCommand("spR_GetChildCategories", con))
        {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ParentId", parentCatId);
        con.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        //rep.DataSource = rdr;
        //rep.DataBind();
        con.Close();
        }
    }
                }
                catch (Exception ex)
                {
                    
                }
            }
