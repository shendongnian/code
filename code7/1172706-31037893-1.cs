    namespace GUITest
    {
      public partial class Form2 : Form
      {
      
        private string _value; // Again your field but this time without your default Value
      
        public Form2(string myVal)
        {
          InitializeComponent();
          _value = myVal;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          if (checkBox1.Checked)
          {
            MessageBox.Show("Value: " + _value); // Here it's now not anymore "Default" :)
          }
          else // Removed redundant if
          {
            MessageBox.Show("Value: " + _value); // TBD
          }
        }
      }
    }
