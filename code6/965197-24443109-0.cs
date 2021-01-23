    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            //Insert Code is here
            lblMessage.text ="Message Here";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
        catch 
        {
            lblMessage.text ="Message Here";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
