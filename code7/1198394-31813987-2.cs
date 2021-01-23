            public Form1()
            {
                InitializeComponent();
                B1.Text = "LOL";
                Control ctl = FindControl(this, "B1");
                if (ctl is TextBox)
                    listBox1.Items.Add(((TextBox)ctl).Text);
            }
            public static Control FindControl(Control parent, string ctlName)
            {
                foreach (Control ctl in parent.Controls)
                {
                    if (ctl.Name.Equals(ctlName))
                    {
                        return ctl;
                    }
    
                    FindControl(ctl, ctlName);
                }
                return null;
            }
