    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && gvCustomers.EditIndex == e.Row.RowIndex)
        {
            DropDownList ddltype = (DropDownList)e.Row.FindControl("ddltype");
            string query = "select distinct paymenttype from paymenttypes";
            SqlCommand cmd = new SqlCommand(query);
            ddltype.DataSource = GetData(cmd);
            ddltype.DataTextField = "type";
            ddltype.DataValueField = "type";
            ddltype.DataBind();
            ddltype.Items.FindByValue((e.Row.FindControl("Label31") as Label).Text).Selected = true;
        }
    }
    private DataTable GetData(SqlCommand cmd)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
