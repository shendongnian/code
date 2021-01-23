    public partial class Form2 : Form, INotifyPropertyChanged
    {
        public Form2()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public new bool Visible
        {
            get 
            {
                return base.Visible; 
            }
            set
            {
                base.Visible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
            }
        }
        private void hideButton_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
