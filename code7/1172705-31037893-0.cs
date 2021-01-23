    namespace GUITest
    {
      public partial class Form1 : Form
      {
        private string _value = "Default"; // Create a private field with your Default Value
        
        public string Value
        {
          get
          {
            return _value;
          }
          set
          {
            _value = value
          }
        }
        public Form1()
        {
          Application.EnableVisualStyles();
          InitializeComponent();
          this.textBox1.Text = Value;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          Value = this.textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          switch (comboBox2.SelectedIndex)
          {
            case -1:
              MessageBox.Show("You didn't choose anything.");
              break;
            case 0:
              MessageBox.Show("Value of variable: " + value); // Here it's the new value, NOT "Default"
              Form2 form_Form2 = new Form2(Value); // Pass the Value to the Constructor of Form2
              form_Form2.ShowDialog();
              break;
          }
        }
      }
    }
