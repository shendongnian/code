    public partial class Form1 : Form
    {
        Control c;
    
        public Form1()
        {
            Task.Factory.StartNew(() => { c = new Control(); });          
        }
    }
