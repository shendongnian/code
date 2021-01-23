    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            LinkButton lb=(LinkButton )GridView1.Rows[index].FindControl("lblCmd");//lblCmd is the Id of Your Link Button
            string id = lb.CommandArgument.ToString();
            string cmdText = lb.Text;
            if (cmdText.Equals("Edit"))
            {
                Response.Redirect("Emp_Edit.aspx?id=" + id);
            }
            else
            {
                Class1.EmpDelete(id);
                Response.Redirect("Emp_Reg.aspx");
            }
        }
