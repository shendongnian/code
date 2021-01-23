    public partial class Form1 : Form
    {
        private void btn_Click(object sender, EventArgs e)
        {
            A obj = new A();
            obj.foo(Test);
        }
        
        public string Test(string par)
        {
            //to_stuff
        }
    }
    class A
    {
        private Func<string, string> _callback;
        public A(Func<string, string> callback)
        {
            _callback = callback;
        }
        public void foo()
            //Do_stuff
            //...
            _callback(Par);
            //Do...
        }
    }
