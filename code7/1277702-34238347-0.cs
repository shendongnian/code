    public partial class SearchForm : Form
    {
         PawningForm f2;
         public void SearchForm(PawningForm caller) 
         {
              f2 = caller;
              InitializeComponent();
         }
         private void button1_Click_1(object sender, EventArgs e)
         {
            lblTest.Text = row.Cells[0].Value.ToString();
            f2.fo = lblTest.Text;
         }
      }
