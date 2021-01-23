    public partial class Form2 : Form
    {
        BindingList<Students> bsStudnew;
        public Form2(BindingList<Students> bs)
        {
            InitializeComponent();
            bsStudnew = bs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Students student = new Students();
            student.Name = textBox1.Text;
            student.Surname = textBox2.Text;
            student.Age = Convert.ToInt32(textBox3.Text);
            bsStudnew.Add(student);
        }
    }
