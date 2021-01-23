    public partial class Form1 : Form
     {
        Methoden m1;
        public Form1()
        {            
            InitializeComponent();
            m1 = new Methoden();
            Parameter p1 = new Parameter();
            m1.InitializeSensors(p1.ISensor);
        }
    
    
    
    
        private void button1_Click(object sender, EventArgs e)
        {
           m1. // this does not work
        }
