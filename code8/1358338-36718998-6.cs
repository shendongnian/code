    public class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
<!---->
    public class BaseForm : Form
    {
        //The property is not visible in designer of BaseForm
        //But you can see it in designer of Form1
        public string SomeProperty {get;set;}
    }
    
