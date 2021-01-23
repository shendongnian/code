    namespace TF2Overwatch
    {
        public partial class TF2SelectDir : Form
        {
            //Approch 1 - usable when the projects most works are done
            //without following a good architecture 
            //You can use a static variable to preserve the state and intilize each time
            //a new instance is created
    
            //Approch 2 - Responibilty of preserving text to initlize in textbox should be taken
            //by the form who calling this form        
            //value will pass by consturtor or by exposing property 
            
            //all approch 2 code are kept commented for better understanding
            private static string strTxtTF2DirSelectTextToInitize;
    
            public TF2SelectDir()
            {
                InitializeComponent();
                txtTF2DirSelect.Text = strTxtTF2DirSelectTextToInitize;
            }
    
            public static string TxtTF2DirSelectTextToInitlize
            {
                get
                {
                    return strTxtTF2DirSelectTextToInitize;
                }
                set
                {
                    strTxtTF2DirSelectTextToInitize = value;
                }
            }
    
            //public TF2SelectDir(string txtTF2DirSelectText)
            //{
            //    InitializeComponent();
            //    txtTF2DirSelect.Text = txtTF2DirSelectText;
            //} 
                   
    
            //public string TxtTF2DirSelectTextToInitlize
            //{
            //    get
            //    {
            //        return txtTF2DirSelect.Text;
            //    }
            //    set
            //    {
            //        txtTF2DirSelect.Text = value;
            //    }
            //}
            
        }
    
        public partial class SomeAnotherForm:Form
        {
            public SomeAnotherForm ()
            {
                InitializeComponent();           
            }
    
            protected void InSomeAction(object Sender, EventArgs e)
            {
                
                if (canFindTF2 == true)
                {                 
                    TF2SelectDir.TxtTF2DirSelectText = "Test";
                    TF2SelectDir t1 = new TF2SelectDir();
                    t1.Show();
    
                    //Approch 2
                    //TF2SelectDir t1 = new TF2SelectDir("Test");
                    //t1.Show();
    
                    //TF2SelectDir t1 = new TF2SelectDir();
                    //t1.TxtTF2DirSelectText="Test"; //look here TxtTF2DirSelectText is setting on instance not by class
                    //t1.Show();
    
                } 
            }
        }
    }
