    public partial class frmCardGame : Form
    {
        // Fields declared here exist as long as the form is open.
        private readonly Random R = new Random();
        private List<int> Deck;
        public frmCardGame()
        {
            InitializeComponent();
            InitializeDeck();
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Variables declared here exist only as long as this method is being executed.
            int card = R.Next(Deck.Count);
            Deck.Remove(card);
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            InitializeDeck();
        }
        private void InitializeDeck()
        {
            Deck = new List<int> { 0, 1, 2, 3};
        }
    }
