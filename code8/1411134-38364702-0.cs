     In a class:
     using System.Windows.Forms;
    namespace getObjectFromaClass
    {
    
    class Class1
    {
       public static TextBox txt1 = new TextBox();
        public void getText()
        {
            try
            {
                txt1.Text = "this is my text";
            }
            catch (Exception er)
            {
                string x = er.Message;
            }
           
        }
    }
     }
    In a form:
    namespace getObjectFromaClass
    {
    public partial class Form1 : Form
    {
        Class1 cls1 = new Class1();
        public Form1()
        {
           
            textBox1=Class1.txt1;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cls1.getText();
            textBox1.Text = Class1.txt1.Text;
        }
    }
     }
