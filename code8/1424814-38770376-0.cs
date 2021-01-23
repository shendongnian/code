    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		// here you create and show secondary form
    		// note that you pass this form as parameter to secondary form
    		Form2 form2 = new Form2(this);
    		form2.ShowDialog();
    	}
    }
