    public partial class Form1 : Form
    {
        UserControl1 UC1 = new UserControl1();
        UserControl2 UC2 = new UserControl2();
        public Form1()
        {
            InitializeComponent();
            UC1.UserControl1Event += new EventHandler(HandleTheEvent);
        }
