    public partial class ArtikelControl : UserControl
    {
        public ArtikelControl()
        {
            InitializeComponent();
        }
        public decimal GP 
        {
            get { return Decimal.Parse(epreisTextBox.Text) *
                         Int32.Parse(mengeTextBox.Text); } // add validation
        }
        public decimal EP { get { return Decimal.Parse(epreisTextBox.Text); } }
        public string Nr { get { return nrTextBox.Text; } }
        public string Bez { get { return bezTextBox.Text; } }
        public string Menge { get { return mengeTextBox.Text; } }
        public bool HasEpreis
        { 
            get { return !String.IsNullOrEmpty(epreisTextBox.Text); } 
        }
    }
