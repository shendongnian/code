    public class Form1 : Form
    {
        public int Foo { get; set; }
    }
    
    public class Form2 : Form
    {
        public Form2(Form1 form1) 
        {
            form1.Foo = 42;
        }
    }
