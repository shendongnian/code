    protected void myForm_DataBound(object sender, EventArgs e)
    {
        if (myForm.CurrentMode == FormViewMode.Insert)
        {
            TextBox tb = (TextBox)myForm.FindControl("IssuedDateTextBox");
            if (String.IsNullOrEmpty(tb.Text.Trim()))
            {
                //set default value - TODAY date
                tb.Text = String.Format("{0:yyyy}{0:MM}{0:dd}", DateTime.Now);
            }
        }
    }  
