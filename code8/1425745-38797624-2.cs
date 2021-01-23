    public partial class list : UserControl
    {
        void chgtxt(Label lbl, string s)
        {
            lbl.Text = s;
        }
    
        public list()
        {
            InitializeComponent();
        }
    
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Yellow;
            chgtxt(label1, "Changed");
    
            if(this.Parent != null)
            {    
                foreach (list listControl in this.Parent.Controls.Cast<Control>().OfType<list>())
                {
                    if (listControl != this)
                    {
                        listControl.Deselect();
                    }
                }
            }
        }
        private void Deselect()
        {
            // Do whatever to show this control as deselected.
        }
    }
