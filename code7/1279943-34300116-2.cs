    public partial class Form3 : Form
    {
        public Form3(BindingList<Students> bsStud)
        {
            InitializeComponent();
            listBox1.DataSource = bsStud;
        }
        ....
     
