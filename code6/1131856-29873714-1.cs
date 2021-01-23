    using System;
    using System.Windows.Forms;
    namespace BlogPartialUpdateTrick
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                var destination = new SomeClass() { FirstName = "Freddy", LastName = "Fingers", Dob = DateTime.Parse("01/01/1970"), HeightInches = 72 };
                var source = new SomeClass() { FirstName = null, LastName="Flippers", Dob = null, HeightInches = 80 };
                destination.SetAll(source);
                MessageBox.Show(destination.ToString());
            }
        }
    }
