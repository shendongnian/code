    try
    {
        if (HelpClass.ParseInput(txtPrice.Text) <= 0)
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
