    protected void btnresult_Click(Object sender, EventArgs e)
        {
            Button btn=(Button)(sender);
            Response.Write("<script>");
            Response.Write("window.open('studentresult.aspx?id="+btn.CommandArgument+"','_blank')");
            Response.Write("</script>");
        }
