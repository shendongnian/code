    using System;
    using System.Windows.Forms;
    
    namespace Test_Desktop
    {
        public partial class FirstForm : Form
        {
            public FirstForm()
            {
                InitializeComponent();
            }
    
            private void showSecondFormButton_Click(object sender, EventArgs e)
            {
                SecondForm secondform = new SecondForm(this); //Passing the reference of current form i.e. first form
                secondform.Show();
                this.Hide();       
            }
        }
    }
