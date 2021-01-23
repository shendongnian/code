    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            //Insert Code is here
            lbl_status.Text = "Record Added Successfully";
            lbl_status.ForeColor = System.Drawing.Color.Green;
        }
        catch 
        {
            lbl_status.Text = "Error";
            lbl_status.ForeColor = System.Drawing.Color.Red;
        }
    }
