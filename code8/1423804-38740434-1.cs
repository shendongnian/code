    // Replace letters and numbers with nothing then check if there are any characters left.
    // The only characters will be something like $, @, ^, or $.
    //
    // \w checks for words.
    if (!string.IsNullOrWhiteSpace(Regex.Replace(input, @"(\w*)", "")))
    {
        // Do whatever with the string.
    }
