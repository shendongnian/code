    public partial class form2 : Form
    {
    public form2()
    {
        InitializeComponent();
    }
    private string _passedValue = "";
    public form2(string passedValue)
    {
        InitializeComponent();
        _passedValue = passedValue;
        listView1.Items.Add(_passedValue);
    }
    
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    }
