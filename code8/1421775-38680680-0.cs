    public class MainForm : Form
    {
    	public void UpdateProductList()
    	{
    		// do something here
    	}
    
    	private void buttonOpenChildFormClick(object sender, EventArgs e)
    	{
    		using (var childForm = new ChildForm(this))
    		{
    			childForm.ShowDialog();
    		}
    	}
    }
    
    public class ChildForm : Form
    {
    	private readonly MainForm _mainForm;
    	
    	public ChildForm(MainForm mainForm)   //send reference of MainForm to ChildForm
    	{
    		_mainForm = mainForm;
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		_mainForm.UpdateProductList();
    	}
    }
