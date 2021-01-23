    List<Color> possibleColors = new List<Color>()
    {
        Color.Red,
        Color.Green,
        Color.Gold,
        Color.Blue
    };
    
    private Color GetRandomColorOfList()
    {
        return possibleColors[random.Next(0, possibleColors.Count)];
    }
    
    private void button5_Click(object sender, EventArgs e)
    {
        button1.BackColor = GetRandomColorOfList();
        button2.BackColor = GetRandomColorOfList();
        button3.BackColor = GetRandomColorOfList();
        button4.BackColor = GetRandomColorOfList();
    }
