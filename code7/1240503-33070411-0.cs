    public MainForm : Form
    {
        public MainForm()
        {
             // code
        }
        public void MenuStrip_OptionSelected(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            switch(MenuStrip.SelectedValue)
            {
                case "UserControl1" : Panel1.Controls.Add(new UserControl1()); break;
                ...
            }
        }
    }
    public UserControl1 : UserControl
    {
        // code
    }
