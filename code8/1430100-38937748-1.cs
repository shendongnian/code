    //FORM1
    public partial class Form1 : Form
    {
        //Instance of this form
        public static Form1 instance;
        
        //For testing
        public string myProperty = "TEST";
        //Assign instance to this either in the constructor on on load like this 
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }
        //or
        private void Form1_Load(object sender, EventArgs e)
        {
            //Assign the instance to this class
            instance = this;
        }
