    var inputText = "12:22"; // get this from whatever your input is
    TimeSpan result;
    if (!TimeSpan.TryParse(inputText, out result))
    {
        // handle error
    }
    else
    {
        // everything okay
    }
