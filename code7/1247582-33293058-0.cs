    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(MouseEventHandler handler)
            : this()
        {
            this.MouseClick += handler;
        }
    }
