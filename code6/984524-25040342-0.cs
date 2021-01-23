    public partial class Auswahl  : Form
    {
        public Auswahl(string[] array)
        {
            InitializeComponent();
            comboBox1.DataSource = array;
        }
    }
