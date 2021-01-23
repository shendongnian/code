    public partial class Form1 : Form
    {
        public static Form1 Instance { get; set; } //Create an Instance Object of your Window
        public Form1()
        {
            InitializeComponent();
        }
        //Your call to open the Window
        private void OpenForm2()
        {
            if (Form2.Instance == null)//Check if this Instance was already chreated
            {
                //if not go create a new one !
                Form2.Instance = new Form2();
            }
            //Instance of Form2 is already created            
            Form2.Instance.Show();
            
        }
    }
    
    public partial class Form2 : Form
    {
        public static Form2 Instance { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
    }
