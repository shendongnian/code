       public partial class Form2 : Form
       {
          public Form2()
          {
             InitializeComponent();
          }
          public string PersonName
          {
             get { return txtName.Text; }
             set { txtName.Text = value; }
          }
          public string NewValue
          {
             get { return txtValue.Text; }
             set { txtValue.Text = value; }
          }
       }
