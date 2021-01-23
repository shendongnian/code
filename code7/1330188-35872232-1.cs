    private static Random rng = new Random();  
    
    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
    List<Color> possibleColors = new List<Color>()
    {
        Color.Red,
        Color.Green,
        Color.Gold,
        Color.Blue
    };
    
    private void button5_Click(object sender, EventArgs e)
    {
        possibleColors.Shuffle();
        button1.BackColor = possibleColors[0];
        button2.BackColor = possibleColors[1];
        button3.BackColor = possibleColors[2];
        button4.BackColor = possibleColors[3];
    }
