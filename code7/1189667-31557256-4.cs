    public partial class MainForm : Form
    {
        AutoClass ac = new AutoClass();
    
        ...
        
        void MyMethod
        {
            List<string> imgcol = ac.imgcol1.imgCollection; 
            // (you don't really need this GetList method of AutoClass at all)
        }
    }
