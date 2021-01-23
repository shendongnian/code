    using System;
    using System.Windows.Forms;
    namespace Test_Desktop
    {
        public partial class SecondForm : Form
        {
            private FirstForm firstForm = null;
            public SecondForm()
            {
                InitializeComponent();
            }
            ///
            /// Overriding constructor
            ///
            public SecondForm(FirstForm firstForm)
            {
                InitializeComponent();
                this.firstForm = firstForm;
            }
            private void showFirstFormButton_Click(object sender, EventArgs e)
            {
                if(firstForm!=null)
                {
                    firstForm.Show();
                    //
                    //Do some processing
                    //
    
                    this.Dispose(); 
                }
            }
        }
    }
