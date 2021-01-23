    public partial class MyForm : Form {
        private int clickcount = 0;
        public MyForm()
        {
            InitializeComponent();
            button1.Click += clicked;
        }
        public void clicked(object sender, EventArgs e)
        {
            if (++clickcount == 10) {
                MessageBox.Show("hello there!");
               clickcount = 0;
            }           
 
        }
    }
