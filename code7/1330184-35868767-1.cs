    List<Color> possibleColors = new List<Color>()
    {
        Color.Red,
        Color.Green,
        Color.Gold,
        Color.Blue
    };
    
    private Color GetRandomColorOfLoist()
    {
        return possibleColors[random.Next(0, possibleColors.Count)];
    }
    
    private void button5_Click(object sender, EventArgs e)
    {
        button1.BackColor = GetRandomColorOfLoist();
        button2.BackColor = GetRandomColorOfLoist();
        button3.BackColor = GetRandomColorOfLoist();
        button4.BackColor = GetRandomColorOfLoist();
    }
