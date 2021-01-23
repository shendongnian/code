    namespace MyProgram
    {
    	class Class1
    	{
    		public static int Class1Variable;
    	}
    }
    
    namespace MyProgram
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void LoadImageButton_Click(object sender, EventArgs e)
    		{
    			//Load image logic
    		}
    
    		private void ResultButton_Click(object sender, EventArgs e)
    		{
    			Class1.Class1Variable = 1;
    		}
    	}
    }
