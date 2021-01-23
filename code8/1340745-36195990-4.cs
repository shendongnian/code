    Dictionary<string, Color> colors = new Dictionary<string, Color>()
    {
        {
            "Red",
            Colors.Red
        },
        {
            "Blue",
            Colors.Blue
        },
        {
            "Green",
            Colors.Green
        },
        {
            "Yellow",
            Colors.Yellow
        }
    };
    var randColName = colors.ToArray()[randIndex];
    txtbKleuren.Text = randColName.Key;
    txtbKleuren.Foreground = new SolidColorBrush(randColName.Value);
        
