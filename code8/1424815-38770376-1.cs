    public partial class Form2 : Form
    {
    	public Form ParentForm { get; set; }
    
    	public Form2(Form parentForm)
    	{
    		InitializeComponent();
    		this.ParentForm = parentForm;
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		if(ParentForm != null)
    			ParentForm.Close();
    	}
    }
