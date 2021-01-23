    class Form1 : Form
    {
    	public void Method()
    	{
    	   var form2 = new Form2();
    	   form2.Owner = this;
    	   form2.ShowDialog();
    	}
    }
    
