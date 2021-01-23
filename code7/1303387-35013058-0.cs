    public partial class Form1 : Form
    {
        public event EventHandler PersonSelected;
        public String PersonName { get; set; }
        public Form1()
        {
            InitializeComponent();
            PersonName = "Person's name";
        }
        protected override void OnClick(EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            PersonSelected(this, EventArgs.Empty);
        }
    }
    public partial class Form2 : Form
    {
        public Form2(Form1 form)
        {
            InitializeComponent();
            form.PersonSelected += (sender, args) =>
            {
                Form1 form1 = sender as Form1;
                if(form1 != null)
                    textBox1.Text = form1.PersonName;
            };
        }
    }
