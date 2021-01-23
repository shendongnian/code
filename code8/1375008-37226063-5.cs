    public partial class DemandePrixFournisseur : Form
    {
    
        private DemandePrixClient info;
    
        public DemandePrixFournisseur(DemandePrixClient information)
        {
            InitializeComponent();
            info = information;
            this.textBox1.Text = info.text1; // you can get other value like this way
            //or simply
            this.textBox2.Text = information.text1;
            // and others textbox and combobox value similarly
        }
    
       
    }
