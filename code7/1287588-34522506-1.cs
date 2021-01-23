    List<string> words = input.Split(' ').ToList(); //Read 1.
    Random rand = new Random(); //Read 2.
    int val = rand.Next(0, words.Count - 5);
    string result = "";
    for (int i = 0; i < 5; ++i)
        result += words[val + i] + (i == 4 ? "" : " "); //read 3.
