    protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
    {            
        foreach (dynamic value in e.Values)
        {
            TextBox txtBox = FormView1.FindControl(value.Key + "TextBox") as TextBox;
            if (txtBox != null)
            {
                Response.Write(txtBox.ID);
            }
        }
    }
