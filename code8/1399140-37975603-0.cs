    public partial class Form1 : Form
    {
      public Form1() {
        InitializeComponent();
        DatabaseClass.Messages.ListChanged += Messages_ListChanged;
      }
    }
    void Messages_ListChanged(object sender, ListChangedEventArgs e) {
      if (e.ListChangedType == ListChangedType.ItemAdded) {
        MessageBox.Show(DatabaseClass.Messages[e.NewIndex].ToString());
      }
    }
