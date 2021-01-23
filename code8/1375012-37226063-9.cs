    public partial class DemandePrixFournisseur : Form
    {
    
        private DemandePrixClient info;
    
        public DemandePrixFournisseur(DemandePrixClient information)
        {
            InitializeComponent();
            info = information;
            this.textBox1.Text = info.text1; // you can get other value like this way
            this.textBox2.Text = info.text2;
            this.textBox3.Text = info.text3;  
            //or simply
            this.textBox2.Text = information.text2;
            // and others textbox and combobox value similarly
        }
    
       
    }
