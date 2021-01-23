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
            label1.Text = "Item Code:" + tmp.pro.product_code;
            label2.Text = "Name:" + tmp.pro.product_name;
            label3.Text = "Price:" + tmp.pro.product_price; 
        }
    }
