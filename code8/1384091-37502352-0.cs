    private Guess guess;
    
    public Form1(Guess guess)
    {
        InitializeComponent();
        this.guess = guess;
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        this.guess.reset();
        this.BackColor = System.Drawing.Color.Gray;
    }
