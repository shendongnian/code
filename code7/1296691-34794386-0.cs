    // A list that will hold the words ending with '//jj'
    List<string> results = new List<string>();
    // The text you provided
    string input = @"ffafa adada//bb adad ssss//jj aad adad adadad aaada dsdsd//jj dsdsd sfsfhf//vv dfdfdf";
    // Split the string on the space character to get each word
    string[] words = input.Split(' ');
    // Loop through each word
    foreach (string word in words)
    {
        // Does it end with '//jj'?
        if(word.EndsWith(@"//jj"))
        {
            // Yes, add to the list
            results.Add(word);
        }
    }
    // Show the results
    foreach(string result in results)
    {
        MessageBox.Show(result);
    }
