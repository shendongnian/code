    using System;
    using System.Windows.Forms;
    
    namespace FormTestApplication
    {
        public partial class Form1 : Form
        {
            private Boolean state = false;  //global variable that updates everyone.
    
            public Form1()
            {
                InitializeComponent();
    
                MyCheck my1 = new MyCheck(ref state);
                my1.Top = 100;
                my1.Left = 100;
                MyCheck my2 = new MyCheck(ref state);
                my2.Top = 120;
                my2.Left = 100;
                MyCheck my3 = new MyCheck(ref state);
                my3.Top = 140;
                my3.Left = 100;
    
                this.Controls.Add(my1);
                this.Controls.Add(my2);
                this.Controls.Add(my3);
    
                state = true;  //changing this one variable should causes all 3 to update to checked.  This does not work.
                
            }
        }
    
        public class MyCheck : CheckBox
        {
    
            private Boolean status
            {
                get { return this.Checked; }
                set
                {
                    this.Checked = value;
                    Invalidate();
                }
            }
    
            public MyCheck(ref Boolean b)
            {
                status =  b;
            }
    
    
    
        }
    }
