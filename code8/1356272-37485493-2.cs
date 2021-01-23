    public partial class Form1 : Form
    {
        private IPresenter _presenter;
        private bool _initialized;
        public Form1(IPresenter presenter)
        {
            InitializeComponent();           
            _presenter = presenter;
            _presenter.Init();
            SetComboBoxData(_presenter.GetCustomers());
            _initialized = true;
        }
        public void SetComboBoxData(IEnumerable data)
        {
            comboBox1.DataSource = data;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "FirstName";
        }
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!_initialized) return;
            _presenter.SetSelectedCustomer((int)comboBox1.SelectedValue);
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            textBox1.DataBindings.Add(new Binding("Text", _presenter, nameof(_presenter.FirstName)));
            textBox2.DataBindings.Add(new Binding("Text", _presenter, nameof(_presenter.LastName)));
            textBox3.DataBindings.Add(new Binding("Text", _presenter, nameof(_presenter.Address)));
        }
    }
