    public partial class Form1 : Form, ITester
    {
        private void btn_Click(object sender, EventArgs e)
        {
            A obj = new A(this);
            obj.foo("test");
        }
    
        public string Test(string value)
        {
            //to_stuff
            return value;
        }
    }
