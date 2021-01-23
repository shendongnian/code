    public partial class myWindow : Form
    {
        private int _roll;
        public Window()
        {
            InitializeComponent();
            Random random = new Random();
            _roll = random.Next(0, 99);
        }
        private void guessButton_Click(object sender, EventArgs e)
        {
            // Check if the player's guess matches _roll
        }
    }
