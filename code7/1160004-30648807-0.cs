    public partial class Form1 : Form
    {
        int test = 1;
        Store<string> store;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            store = new Store<string>(() => test.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            test = 7;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = store.GetValue();
        }
    }
    public class Store<T>
    {
        private Func<T> function;
        public Store(Func<T> function)
        {
            this.function = function;
        }
        public T GetValue()
        {
            return function();
        }
    }
