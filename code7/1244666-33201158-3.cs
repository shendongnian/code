    public partial class Form1 : Form
    {
        #region Declaration
        Image[] diceImages;
        Label[] labels;
        List<int> dice;
        int diceTotal;
        bool checkOnesAndFours;
        Random random;
        #endregion
    
        #region Initialiazation;
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initializing an array this way eliminates the chance of having
            // a typo in the array index for the assignment.
            diceImages = new Image[]
            {
                Properties.Resources.blank,
                Properties.Resources.one,
                Properties.Resources.two,
                Properties.Resources.three,
                Properties.Resources.four,
                Properties.Resources.five,
                Properties.Resources.six
            };
            // Lists must be initialized explicitly with their initial values, as by default
            // they are initially empty.
            dice = new List<int>(Enumerable.Repeat(0, 5));
    
            random = new Random();
    
            diceTotal = 0;
            // For the purposes of setting the dice images, it will be helpful
            // to keep the control references in an array. This is both convenient
            // and, again, helps guard against typographical errors
            labels = new Label[]
            {
                lbl_dice1,
                lbl_dice2,
                lbl_dice3,
                lbl_dice4,
                lbl_dice5
            };
        }
    
        #endregion
    
        #region Private Methods
    
        private void btn_rollDice_Click(object sender, EventArgs e)
        {
            RollDice();
        }
    
        private void RollDice()
        {
            bool rolledOneOrFour = false;
            int rollTotal = 0;
            for (int i = 0; i < dice.Count; i++)
            {
                // Clear any 1 or 4 from the previous roll
                if (checkOnesAndFours && (dice[i] == 1 || dice[i] == 4))
                {
                    // Remove this die from play
                    dice.RemoveAt(i);
                    // The next list element to examine is now at the current i value
                    // and the for loop is going to increment i when the continue
                    // is executed, so decrement i in anticipation of that
                    // so that the loop moves on to the correct next element
                    i--;
                    continue;
                }
                dice[i] = random.Next(1, 7);
                if (dice[i] == 1 || dice[i] == 4)
                {
                    rolledOneOrFour = true;
                }
                rollTotal += dice[i];
            }
            if (!rolledOneOrFour)
            {
                diceTotal += rollTotal;
            }
            checkOnesAndFours = true;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Image = i < dice.Count ? diceImages[dice[i]] : diceImages[0];
            }
        }
    
        #endregion
    }
