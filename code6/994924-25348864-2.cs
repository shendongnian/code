        public partial class Form2 : Form
    {
        public Form2(IPSettings ipSettings)
        {
            InitializeComponent();
            textBoxIpAddress2.DataBindings.Add("Text", ipSettings, "IPAddress",false,DataSourceUpdateMode.OnPropertyChanged);
        }
    }
