    public partial class addtoLibraryDialog : Form
    {
      internal MainForm mainfom ; // Change "MainForm" by real form name 
    
      public addtoLibraryDialog()
      {
        InitializeComponent();
      }
      private void btnOK_Click(object sender, EventArgs e)
      {
        ListViewItem list = new ListViewItem("name");
        list.SubItems.Add("path");
        mainfom.listView1.Items.Add(list);
      }
     }
