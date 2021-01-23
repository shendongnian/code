    public partial class SampleForm : Form
    {
        public SampleForm()
        {
            InitializeComponent();
        }
        private void SampleForm_Load(object sender, EventArgs e)
        {
            //Initialize parent and populate its Childs
            var parent = new Parent()
            {
                ParentName = "Parent 1",
                Childs = new List<Child>{
                    new Child(){ChildName= "Child1"},
                    new Child(){ChildName= "Child2"}
                }
            };
            this.comboBox1.DataSource = parent.Childs;
            this.comboBox1.DisplayMember = "ChildName";
            this.comboBox1.ValueMember = "ChildName";
        }
    }
    public class Parent
    {
        public Parent()
        {
            Childs = new List<Child>();
        }
        public string ParentName { get; set; }
        public List<Child> Childs { get; set; }
    }
    public class Child
    {
        public string ChildName { get; set; }
    }
