    public partial class form1 : Form
    {
    public form1()
    {
        InitializeComponent();
    }
    public static string buttonValue = "";
    public void button1_Click(object sender, EventArgs e)
    {
        buttonValue = "Vanillaaaa";
    }
    private void button2_Click(object sender, EventArgs e)
    {
        buttonValue += "~Chocolate";
    }
    private void button3_Click(object sender, EventArgs e)
    {
        form2 form2 = new form2(buttonValue);
        form2.Show();
        this.Hide();
    }
    public partial class form2 : Form
    {
        public form2(string passedValue)
        {
            InitializeComponent();
           string[] _passedValue = passedValue.Split('~');
            listView1.Items.Add(_passedValue[0]);
            listView1.Items.Add(_passedValue[1]);
    
        }
