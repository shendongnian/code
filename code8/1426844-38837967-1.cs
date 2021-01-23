    public Foo : UserControl {
        public TabControl tabControl { get; set; }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if(tabControl == null) {
                // do nothing - ignore button click.
            } else {
                TabPage tp = new TabPage { };
                tp.Text = "NewTab";
                tp.Controls.Add(new b());
                tabControl.TabPages.Add(tp);  //>>> errors here
            }
        }
    }
