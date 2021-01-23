    public class BaseForm
    {
        //The property is not visible in designer of BaseForm
        //But you can see it in designer of Form1
        public string SomeProperty {get;set;}
    }
    
    public class Form1:BaseForm
    {
    }
