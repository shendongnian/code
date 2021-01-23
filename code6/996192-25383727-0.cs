    protected void Button1_Click(object sender, EventArgs e)
    {
    foreach (GridViewRow gvr in GridView1.Rows)
       {
        RadioButton rb = (RadioButton)gvr.FindControl("RadioButton1");
        if (rb.Checked)
        {
            HiddenField hf = (HiddenField)gvr.FindControl("HiddenField1");
            Response.Write(rb.Text.ToString() + "<br />" + hf.Value.ToString());
        }
        else
        {
            Response.Write("empty<br />");
        }
    }
    }
