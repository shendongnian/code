    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public void ShowThis<T>(IEnumerable<T> data)
        {
            listBox.Items.Clear();
            foreach(var item in data)
            {
                listBox.Items.Add(item);
            }
            this.Show();
        }
    }
