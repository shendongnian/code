    public partial class form2 : Form
    {                   
        public form2(List<string> passedValues)
        {
            InitializeComponent();
            foreach(var item in passedValues)
            {
               listView1.Items.Add(item);
            }
        }
    }
