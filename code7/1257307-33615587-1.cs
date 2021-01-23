    Random rnd = new Random();
    var values = new List<int>(nums); // 1
    int[] card1 = new int[6];
    for (int i = 0; i < card1.Length; i++)
    {
        var rand = rnd.Next(0, values.Count); // 2
        card1[i] = values[rand]; // 3
        values.RemoveAt(rand); // 4
    }
