    public partial class ChooseAccountWindow : MetroWindow
    {
        public string Result { get; set; }
        
        public ChooseAccountWindow()
        {
            InitializeComponent();
        }
        private void btnDastaschentuch2013_Click(object sender, RoutedEventArgs e)
        {
            this.Result = "dastaschentuch2013";
            this.Close();
        }
        private void btnSkeptar_de_Click(object sender, RoutedEventArgs e)
        {
            this.Result = "skeptar_de";
            this.Close();
        }
        private void btnTrachsel_de_Click(object sender, RoutedEventArgs e)
        {
            this.Result = "trachsel_de";
            this.Close();
        }
    }
