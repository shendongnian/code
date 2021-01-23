    string input = "the input sentence, blabla";
    input = input.Replace(",","").Replace(".",""); //Read 1. add as many replace as you want
    List<string> words = input.Split(' ').Distinct.ToList(); //Read 2. and 3.
    Random rand = new Random(); 
    List<int> vals = new List<int>();
    
    do { //Read 4.
        int val = rand.Next(0, words.Count);
        if (!vals.Contains(val))
            vals.Add(val);
    } while (vals.Count < 5);
    string result = "";
    for (int i = 0; i < 5; ++i)
        result += words[vals[i]] + (i == 4 ? "" : " "); //read 5. and 6.
