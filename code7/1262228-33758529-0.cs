     // Form1 is the 1st form or main form
     public partial class Form1 : Form
        {
           
            public Form1()
            {
                InitializeComponent();
    
                //creat a sample object of FormEXt
                var form = new FormExt();
                //subscribe its CustomClose Event
                form.CustomClose += new FormExt.CloseMeDelegate(form_CustomClose);
                //set the text
                form.Text = "Samplee 01";
                //show the form
                form.Show();
    
                //repeat a again 
                form = new FormExt();
                form.CustomClose += new FormExt.CloseMeDelegate(form_CustomClose);
                form.Text = "Samplee 02";
                form.Show();
            }
    
            void form_CustomClose(Form form)
            {
                //get the form show the titile
                MessageBox.Show("Going to Close" + form.Text);
                //close the form
                form.Close();
            }
        }
    
         //second form with a button 
        public class FormExt : Form 
        {
            //creat a delegate which takes form as input
            public delegate void CloseMeDelegate(Form form);
    
            //creat event from delegeate set it fake delegate in order to avoid null excpetion
            public event CloseMeDelegate CustomClose = delegate { 
               
            };
    
            public FormExt() {
    
                //creat a button
                var button = new Button() { Text = "Click" , Top = 10 , Left=10 };
                
                //grab button click event
                button.Click += delegate
                {
                    //invoke custome close event
                    CustomClose(this);
                };
                //add button on the form
                this.Controls.Add(button);
              
            }
        
        }
