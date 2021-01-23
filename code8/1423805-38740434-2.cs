    // Replace letters and numbers with nothing then check if there are any characters left.
    // The only characters will be something like $, @, ^, or $.
    //
    // [\p{L}\p{Nd}]+ checks for words/numbers in any language.
    if (!string.IsNullOrWhiteSpace(Regex.Replace(input, @"([\p{L}\p{Nd}]+)", "")))
    {
        // Do whatever with the string.
    }
