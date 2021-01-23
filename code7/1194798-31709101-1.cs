    partial class Form1 : Form
    {    
       public Form1()
       {
          InitializeComponent();
          this.FormClosing += Form1_FormClosing;
       }
    
       private void Form1_FormClosing(object sender, FormClosingEventArgs e)
       {
           //sql server queries to be executed
           lblSucessMessage.Text = "Succesfully logged out";
       }    
    }
