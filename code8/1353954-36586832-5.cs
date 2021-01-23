    namespace MyProgram
    {
    	class Class1
    	{
    		public int Class1Variable;
    		
    		public Class1()
    		{
    		}
    	}
    }
    
    namespace MyProgram
    {
    	public partial class Form1 : Form
    	{
    		public Class1 c1;
    		
    		public Form1()
    		{
    			InitializeComponent();
    			c1 = new Class1();
    		}
    
    		private void LoadImageButton_Click(object sender, EventArgs e)
    		{
    			//Load image logic
    		}
    
    		private void ResultButton_Click(object sender, EventArgs e)
    		{
    			c1.Class1Variable = 1;
    		}
    	}
    }
