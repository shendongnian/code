    public Form1()
    {
        InitializeComponent();
        Random rnd = new Random();
        int guess = rnd.Next(1, 100);
		button1.Click += (s, e) =>
		{
			MessageBox.Show(Convert.ToString(guess));
		};
    }
