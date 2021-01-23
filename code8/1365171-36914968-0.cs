    namespace Bus
    {
       public partial class Form2 : Form
       {
          public Form2()
          {
             InitializeComponent();
          }
    
          public String SelectedItem {
            get {
              if (null == listBox1.SelectedItem)
                return "";
    
              return listBox1.SelectedItem.ToString() 
            }
          } 
    
          private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
          {
             groupBox1.Text = SelectedItem;
          }
       }
    }
