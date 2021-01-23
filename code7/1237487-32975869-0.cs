    using System;
    namespace MyApps
    {
        public partial class SecondForm: Form
        {
            private string _formType;
            public SecondForm()
            {
                InitializeComponent();
            }
            public SecondForm(string FormType):this()
           {
              _formType = FormType;
            }
            private void btnBack_Click(object sender, EventArgs e)
            {
                // +++++++++++ Need To Write The UPDATED Code Here +++++++++++
                 if(string.IsNullorEmpty(_formType) || _formType.Equals("MainForm"))
              {
                MainForm openForm= new MainForm();
                openForm.Show();
                this.Hide();
               }
               else
               { 
                  // code to open third form
               }
            } 
        }
    }
