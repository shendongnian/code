    namespace TF2Overwatch
    {
        public partial class TF2SelectDir : Form
        {
            public TF2SelectDir()
            {
                InitializeComponent();
            }        
    
            private void InitializeComponent()
            {
                throw new NotImplementedException();
            }
    
            //Your should not exopose the whole control that will not be a good practice
            public string TxtTF2DirSelectText
            {
                get
                {
                    return this.txtTF2DirSelect.Text;
                }
                set
                {
                    this.txtTF2DirSelect.Text = value;
                }
            }
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
                    TF2SelectDir TF2SelectDir = new TF2SelectDir();
                    TF2SelectDir.TxtTF2DirSelectText = "";
                } 
            }
        }
    }
