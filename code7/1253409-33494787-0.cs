    namespace Printing_io
    {
        public partial class Form1 : Form
        {
            public class Testing
            {
                public void myMethod(Form1 form)
                {
                   form.doingThing();  // error here
                }
            }
    
            public Form1()
            {
                InitializeComponent();            
            }
    
            public void doingThing()
            {
            }
        }
    }
