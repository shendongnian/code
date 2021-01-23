    protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert Code is here
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "Message Here", false);
            }
            catch 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "Message Here", false);
            }
        }
