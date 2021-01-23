    protected void Page_Load(object sender, EventArgs e)
        {
            createBoxes();
        }
        string[] boxNames = { "One", "Two", "Three" };
        private void createBoxes()
        {
            int x = 0;
            int y = 10;
            Panel p = new Panel();
            foreach (string name in boxNames)
            {
                
                Label l = new Label();
                l.ID = "lbl_" + name;
                l.Text = "Select Value " + name;
                l.Style.Add("float", "left");
                DropDownList c = new DropDownList();
                c.ID = "cbx_" + name;
                c.Items.Add("Select One");
                for (int i = 1; i < 101; i++)
                {
                    c.Items.Add(i.ToString());
                }
                c.SelectedIndex = 0;
                c.AutoPostBack = true;
                c.Style.Add("display", "block");
                c.SelectedIndexChanged += cbx_Changed;
                p.Controls.Add(l);
                p.Controls.Add(c);
            }
            
            Label lbl_Total = new Label();
            lbl_Total.Text = "Your Total:";
            TextBox txt_Total = new TextBox();
            txt_Total.ID = "txt_Total";
            txt_Total.Width = 75;
            p.Controls.Add(lbl_Total);
            p.Controls.Add(txt_Total);
            p.Width = 300;
            p.Height = 200;
            div_Boxes.Controls.Add(p);
        }
        protected void cbx_Changed(object sender, EventArgs e)
        {
            bool proceed = true;
            int total = 0;
            foreach (string name in boxNames)
            {
                DropDownList c = (DropDownList)findControl(this.Page.Controls,"cbx_" + name);
                if (c.SelectedIndex == 0)
                {
                    proceed = false;
                }
                else
                {
                    total += c.SelectedIndex;
                }
            }
            if (proceed)
            {
                ((TextBox)findControl(this.Page.Controls,"txt_Total")).Text = total.ToString("C2");
            }
        }
        private Control findControl(ControlCollection page, string id)
        {
            foreach (Control c in page)
            {
                if (c.ID == id)
                {
                    return c;
                }
                if (c.HasControls())
                {
                    var res = findControl(c.Controls, id);
                    if (res != null)
                    {
                        return res;
                    }
                }
            }
            return null;
        }
