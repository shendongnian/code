         public partial class Form1 : Form
            {
                internal static Form1 ViewForm1; // Make other form run Public void from Form1
                public form1()
                {
                    InitializeComponent();
                    ViewForm1 = this;  //Add this
                }
                public void DoSomething()
                {
                  //Code here...
                }
        }	
    	
         public partial class Form1 : Form
            {
                public form2()
                {
                    InitializeComponent();            
                    Form1.ViewForm1.ShowData(); // Call public void from form1
                }
    		}
