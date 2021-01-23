    public class Form1 : BaseForm
    {
        //...
    }
<!---->
    public class BaseForm : Form
    {
        //The property is not visible in designer of BaseForm
        //But you can see it in designer of Form1
        public string SomeProperty {get;set;}
    
        //...
    }
    
