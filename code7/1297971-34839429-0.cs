     protected void submit_Click(object sender, EventArgs e)
        {
            basicinfo bn = new basicinfo();
            bn.fname= fname.Text; //textbox value to object
            FirstName.Text = bn.fname; //object value to label
        }
 
