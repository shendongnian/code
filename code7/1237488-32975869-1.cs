    using System;
        namespace MyApps
        {
            public partial class SecondForm: Form
            {
                private Form _previousForm;
                public SecondForm()
                {
                    InitializeComponent();
                }
                public SecondForm(Form form):this()
               {
                  _previousForm = form;
                }
                private void btnBack_Click(object sender, EventArgs e)
                {
                   
                     
                                    _previousForm.Show();
                    this.Hide();
                   
                } 
            }
        }
