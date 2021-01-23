    public partial class Form1 : Form
        {
            private static Form1 _instance; 
            public Form1()
            {
                
                InitializeComponent();
                _instance = this; 
            }
    
          
            public string TextStatus
            {
                get { return StatusLabel.Text;  }
                set { StatusLabel.Text = value;  }
    
            }
            
            public static Form1 Instance { get { return  _instance;  }}
            
    
       
        }
    void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Form1.Instance.TextStatus ="On"; // nothing is changed in label
            //MessageBox.Show("On");
        }
