    public partial class Form1 : Form
    {
        #region Declaration
        Image[] diceImages;
        Label[] labels;
        int[] dice;
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
                Properties.Resources.blank;
                Properties.Resources.one;
                Properties.Resources.two;
                Properties.Resources.three;
                Properties.Resources.four;
                Properties.Resources.five;
                Properties.Resources.six;
            };
    
            // Arrays are always initialized with the elements having their default
            // values, so there's no need to specify `0` values for `int` arrays explicitly
            dice = new int[5];
    
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
            for (int i = 0; i < dice.Length; i++)
            {
                if (checkOnesAndFours)
                {
                    // First, clear any 1 or 4 from the previous roll
                    if (dice[i] == 1 || dice[i] == 4)
                    {
                        dice[i] = 0;
                    }
                    // Then, ignore any blank die
                    if (dice[i] == 0)
                    {
                        continue;
                    }
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
                labels[i].Image = diceImages[dice[i]];
            }
        }
    
        #endregion
    }
