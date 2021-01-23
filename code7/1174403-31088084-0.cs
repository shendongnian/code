        string text = "I have asked the question in StackOverflow. Therefore i can expect answer here.";
        string key = "the question";
        int gram = key.Split(' ').Count();
        var parts = text.Split(' ');
        List<string> n_grams = new List<string>();
        for (int i = 0; i < parts.Count(); i++)
        {
            if (i <= parts.Count() - gram)
            {
                string sequence = "";
                for (int j = 0; j < gram; j++)
                {
                    sequence += parts[i + j] + " ";
                }
                if (sequence.Length > 0)
                    sequence = sequence.Remove(sequenc.Count() - 1, 1);
                n_grams.Add(sequence);
            }
        }
        int count = n_grams.Count(p => p == key);
    }
