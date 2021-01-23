    void panel1_Click(object sender, EventArgs e)
    {
        Panel p = (Panel)(sender);
        UserControl tmp;
        foreach (Control control in MainForm.Controls)
        {
            if (control is UserControl)
            {
                if (control.Name == "MyUserControlName")
                {
                    tmp = control as UserControl;
                }
            }
        }
        //Let's check that we got the control
        if (tmp != null)
        {
            //Now find the controls / Variables that are holding your values in the user control first - I'm assuming textboxes
            TextBox txtProductCode = tmp.Controls.Find("TextBox1",false);
            TextBox txtProductName = tmp.Controls.Find("TextBox2",false);
            TextBox txtProductPrice = tmp.Controls.Find("TextBox3",false);
            label1.Text = "Item Code:" + txtProductCode.Text;
            label2.Text = "Name:" + txtProductName.Text;
            label3.Text = "Price:" + txtProductPrice.Text; 
        }
    }
