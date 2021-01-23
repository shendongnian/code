    class Tricky
    {
        public int Property1
        {
            get
            {
                Program.instance = null;
                return 1;
            }
        }
        public int Property2
        {
            get
            {
                return 2;
            }
        }
    }
    class Program
    {
        public static Tricky instance = new Tricky();
        public static void Main(string[] arg)
        {
            var x = instance?.Property1;
            var y = instance?.Property2;
            //what do you think the values of x,y
        }
    }
