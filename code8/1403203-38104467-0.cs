    string[] words = File.ReadAllLines(sourceDirTemp + comboBox_filename.SelectedItem.ToString();
    foreach(var word in words)
    {
        // moreOrOneWord.Length would allow you to check whether it is a phrase
        string [] moreOrOneWord = words.Split(' ');
        var query = LoadComments().AsEnumerable().Where(r =>
                moreOrOneWord.Any(wordOrPhrase => Regex.IsMatch(r.Field<string>("Column_name"), @"\b" 
                    + Regex.Escape(wordOrPhrase) + @"\b", RegexOptions.IgnoreCase)));
        // Do something with the query...
    }
