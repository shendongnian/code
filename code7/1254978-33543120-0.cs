    public class MyBinding : Binding
    {
        ...
        private string a;
        public string A
        {
            get { return a; }
            set
            {
                a = value;
                Converter = new ValueConverter(a);
            }
        }
    }
