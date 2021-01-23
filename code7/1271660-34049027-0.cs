    protected void grvStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = (DropDownList)e.Row.FindControl("drpQualification");
            ddl.DataSource = your_data_source_here;
            ddl.DataBind();
        }
    }
