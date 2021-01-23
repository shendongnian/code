    try
    {
        if (HelpClass.ParseInput(txtPrice.Text) <= 0) // No more code in the try block will be executed if ParseParse throws an exception
        {
            ok = false;
        }
        else
        {
            newGame.Price = HelpClass.ParseInput(txtPrice.Text);
            _mGames.AddNewGame(newGame);
        }
    }
    catch (CustomException ex)
    {
        // exception handling logic goes here
    }
