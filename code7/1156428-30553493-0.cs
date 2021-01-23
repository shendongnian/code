    public Form1()
        {
            InitializeComponent();
            TabControl tb = new TabControl();
            tb.Width = 500;
            TabPage tp = new TabPage("Tab 1");
            Label lb = new Label();
            lb.Text = "Test";
            lb.Name = "lblTest";
            lb.Location = new Point(10, 10);
            TextBox txt = new TextBox();
            txt.Text = "Textbox";
            txt.Name = "txtName";
            txt.Location = new Point(200, 10);
            tp.Controls.Add(lb);
            tp.Controls.Add(txt);
            tb.Controls.Add(tp);
            radPageViewPage1.Controls.Add(tb);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var crl = FindControl("txtName");
            MessageBox.Show(crl.Text);
        }
        Control FindControl(string target)
        {
            return FindControl(this, target);
        }
        static Control FindControl(Control root, string target)
        {
            if (root.Name.Equals(target))
                return root;
            for (var i = 0; i < root.Controls.Count; ++i)
            {
                if (root.Controls[i].Name.Equals(target))
                    return root.Controls[i];
            }
            for (var i = 0; i < root.Controls.Count; ++i)
            {
                Control result;
                for (var k = 0; k < root.Controls[i].Controls.Count; ++k)
                {
                    result = FindControl(root.Controls[i].Controls[k], target);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
