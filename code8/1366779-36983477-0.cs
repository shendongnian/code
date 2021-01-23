         public partial class Form1 : Form
            {
                ErrorProvider err = new ErrorProvider();
        
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
        
                }
      private void ClearError()       
            {
    
               // ErrorProvider err = new ErrorProvider();
                
                foreach (Control cn in this.Controls)
                {
                    
                    err.SetError(cn,"");
                  
                    err.Clear();
                    cn.BackColor = Color.White;
    
                }
            }
