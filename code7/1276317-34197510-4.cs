    public Form1()
    {
        InitializeComponent();
        string imgN = @"d:\scrape\gears\gear_12x4hand.png";
        img = Image.FromFile(imgN);
        iLoc = new Point(100, 100);
        overlaidButtons.AddRange(new []{button10,button11,button12,button13 });
        // each button calls the same paint event
        foreach (Button btn in overlaidButtons) btn.Paint += btn_Paint;
            
    }
