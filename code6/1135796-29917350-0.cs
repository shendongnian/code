    public partial class ComboBoxControl : UserControl, INotifyPropertyChanged
    {
        public ComboBoxControl()
        {
            InitializeComponent();
        }
        public string LabelText
        {
            get;
            set;
        }
        private string _dataBindingFilter;
        public string DataBindingFilter
        {
            get
            {
                return _dataBindingFilter;
            }
            set
            {
                if (value != _dataBindingFilter)
                {
                    _dataBindingFilter = value;
                    NotifyPropertyChanged("DataBindingFilter");
                }
            }
        }
        public DataTable DataSource
        {
            get;
            set;
        }
        public string DisplayMember
        {
            get;
            set;
        }
        public string ValueMember
        {
            get;
            set;
        }
        public ComboBoxControl ChildControl
        {
            get;
            set;
        }
        public void BindComboBox()
        {
            comboBox1.SelectedIndexChanged -= new EventHandler(comboBox1_SelectedIndexChanged);
            if (string.IsNullOrEmpty(DataBindingFilter))
            {
                comboBox1.DataSource = DataSource;
            }
            else
            {
                DataView view = DataSource.AsDataView();
                view.RowFilter = DataBindingFilter;
                comboBox1.DataSource = view;
            }
            comboBox1.DisplayMember = DisplayMember;
            comboBox1.ValueMember = ValueMember;
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChildControl != null)
            {
                ChildControl.DataSource = DataSource;
                ChildControl.ValueMember = ValueMember;
                ChildControl.DisplayMember = DisplayMember;
                ChildControl.DataBindingFilter = ChildControl.ValueMember + "<>" + comboBox1.SelectedValue;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            BindComboBox();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
