    public partial class Form_2 : Form
    {
       //...
       public Form_2()
       {
           InitializeComponent();
           // your other code
         
           label_two.TextChanged += label_two_TextChanged;
       }
    
       // the event handler
       private void label_two_TextChanged(object sender, EventArgs e)
       {
           label_reader.Text = label_two.Text; // or what ever you want to do
       }
    }
  
