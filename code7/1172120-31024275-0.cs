    string[,] marksMatrix = new string[4, 5];
    string[] studentIDArr = new string[5];
    var lines = File.ReadAllLines("C:/Users/Y400/dDesktop/CTPrac/CTPrac/input.txt");
    for (int i = 0; i < lines.Length; i++)
    {
        var parts = lines[i].Split(new[] {';', ' ' });
        studentIDArr[i] = parts[0];
        for (int j = 1; j < parts.Length; j++)
        {
            marksMatrix[j - 1, i] = parts[i];
        }
    }
