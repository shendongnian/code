    public partial class MyTreeView : UserControl
        {
            //create a custom event
            [Browsable(true)]
            public event TreeViewEventHandler AfterSelect;
            public MyTreeView()
            {
                InitializeComponent();
            }
    
            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
              
                if (AfterSelect != null) {
                   //raise the event , as it is subscribed may be in winform
                    AfterSelect.Invoke(sender, e);
                }
            }
        }
