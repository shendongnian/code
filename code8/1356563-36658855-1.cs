    static void Main(string[] args)
    {
        string input = "00B50578 00A41434 00B50578";
        string foo = "6F6F6F6F6F";
        // start with a queue of characters filled with the
        // letters we are going to put into the input string.
        Queue <char> fooQueue = new Queue<char>(foo); 
    
        StringBuilder result = new StringBuilder();
        // iterate through each split, so that we maintain spaces.
        foreach (var item in input.Split(' '))
        {
            // go through each set of two characters in this specific chunk.
            for (int i = 0; i < item.Length - 1; i += 2) 
            {
                var substring = item.Substring(i, 2); // look at each chunk.
                if (substring == "00") // if the chunk is 00, then append 00. 
                {
                    result.Append("00");
                }
                else // otherwise
                {
                    // take either the next two characters out of the queue
                    //and append them, or if the queue is empty, append the 
                    //letters from the original text.
                    for (int j = 0; j < 2; j++) 
                    {
                        if (fooQueue.Count >= 1)
                            result.Append(fooQueue.Dequeue());
                        else
                            result.Append(substring[j]);
                    }
                }
            }
            // add a space at the end of the chunk. 
            result.Append(' ');
        }
        // print all the chunks, but trim the end (which should at 
        // this point have an additional space at the end.
        Console.WriteLine(result.ToString().Trim());
    }
