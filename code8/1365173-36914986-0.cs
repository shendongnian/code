    namespace Bus
    {
       public partial class Form2 : Form
       {
          public string selectedItem {get; private set}
          //private string selectedItem;
    
          public Form2()
          {
             InitializeComponent();
             selectedItem=listBox1.SelectedItem.ToString();
          }
    
          private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
          {
             groupBox1.Text=selectedItem;
          }
       }
    }
