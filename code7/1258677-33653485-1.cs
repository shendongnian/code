    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cake2 test = new cake2();
            test.cakes = 2; //inheritance
            test.CakeSize= 50; //not inheritance
            MessageBox.Show(test.cakes.ToString() + " | " + test.CakeSize.ToString());
        }
    }
    public class cake
    {
        private int _cakes;
        public int cakes // get value
        {
            get
            {
                return _cakes;
            }
            set
            {
                _cakes = value;
            }
        }
        public cake()
        {
            public cake() : this(0) { } //constructor chaining.  Call your original function if no value is passed in
        }
        public cake(int number) // constructor
        {
            _cakes = number;
        }
        public static int cakes_plus_number(int n) // number plus constant //I don't see the need for static here, but whatever.
        {
            return n + 42;
        }
    }
    public class cake2 : cake
    {
        private int _cake2;
        public int cakes2
        {
            get { return _cake2; }
            set { _cake2 = value; }
        }
        private int _size;
        public int CakeSize
        {
            get { return _size; }
            set { _size = value; }
        }
           
      }
    }
