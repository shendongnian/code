    protected void getQty(object sender, EventArgs e)
    {
        //After clicking "add"....
        string s;
        for(i=0; i < gvChild.Rows.Count; i++)
        {
            s = ((TextBox)gvChild.Rows[i].FindControl("TextBox1")).Text; 
        }
        //Do what you want to with this string
    }
