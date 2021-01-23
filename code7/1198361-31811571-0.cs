    public partial addtoLibraryDialog : Form
    {
      private readonly ListView _listViewItem;
      public addtoLibraryDialog(ListView listViewItem)
      { 
        InitializeComponent();
        this._listViewItem = listViewItem;
      }
      private void btnOK_Click(object sender, EventArgs e)
      {
        list = new ListViewItem("name");
        list.SubItems.Add("path");
        this._listViewItem.Items.Add(list);
      }
    }
    public class MyClass
    {
      public void Main()
      {
        addtoLibraryDialog popupForm = new addtoLibraryDialog(this.ListViewItem1);
        addtoLibraryDialog.ShowDialog();
      }
    }
