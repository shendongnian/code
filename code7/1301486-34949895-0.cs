    public partial class Form1
    {
        private readonly ListView form2ListView;
        public Form1() { //... default initialization }
        // constructor with ListView as argument
        public Form1(ListView _form2ListView)
        {
             form2ListView = _form2ListView;
        }
    }
