    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            // variable to store index of tab which was most recently selected
            private int lastSelectedTabIndex = -1;
    
            public Form1()
            {
                InitializeComponent();
    
                // initialise the last selected index
                lastSelectedTabIndex = tabControl1.SelectedIndex;
            }
            private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
            {
                // sanity check: if something went wrong, don't try and display non-existent tab data
                if (lastSelectedTabIndex > -1)
                {
                    MessageBox.Show(string.Format("Previous tab: {0} - {1}", lastSelectedTabIndex, tabControl1.TabPages[lastSelectedTabIndex].Text));
                }
    
                // store this tab as the one which was most recently selected
                lastSelectedTabIndex = tabControl1.SelectedIndex;
            }
        }
    }
