    public partial class Base : Form
    {
        private MPlayer Player;
        private StreamWriter PlayerInput;
        public Base()
        {
            InitializeComponent();
        }
        private void Base_Load(object sender, EventArgs e)
        {
            Player = new MPlayer((int)Video.Handle);
            Player.Start();
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            Player.End();
        }
    }
