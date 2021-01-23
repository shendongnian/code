    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    int index = Convert.ToInt32(e.CommandArgument.ToString());
    LinkButton lb=(LinkButton )GridView1.Rows[index].FindControl("lblCmd");//lblCmd is the Id of Your Link Button
    if(e.CommandName=="Edit")
    {
      Response.Redirect("Emp_Edit.aspx?id=" + lb.CommandArgument);
    }
    else
    {
        Class1.EmpDelete(idlb.CommandArgument;
        Response.Redirect("Emp_Reg.aspx");
    }
    }
