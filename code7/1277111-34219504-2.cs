    int stub;
    if (_count.Any(x => !int.TryParse(x, out stub)))
    {
        // There is a non-integer string somewhere!
    }
    for (int j = 0; j < keypressLength; j++) //loop through all indices
    {
        for (int i = 0; i < int.Parse(_count[j]); i++)
        {
            ConvertCommand(_keypress[j]);
            Thread.Sleep(100); // wait time after each keypress
        }
     }
