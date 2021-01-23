    public class Products : Form
    {
    	public void UpdateProductList()
    	{
    		// do something here
    	}
    
    	private void buttonOpenChildFormClick(object sender, EventArgs e)
    	{
    		using (var addProduct = new Add_product(this)) //send this reference of MainForm to ChildForm
    		{
    			addProduct.ShowDialog();
    		}
    	}
    }
    
    public class Add_product : Form
    {
    	private readonly Products _products;
    	
    	public Add_product(Products products) //send reference of MainForm to ChildForm
    	{
    		_products = products;
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		_products.UpdateProductList();
    	}
    }
