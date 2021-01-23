    for (int i = 0; i < Board.Length - 2; i++)
    {
        object a = Board[i].Content;
        object b = Board[i + 1].Content;
        object c = Board[i + 2].Content;
        if (a == b && a == c &&
            (string) a != string.Empty && a != null)
        {
            MessageDialog msd = new MessageDialog("test");
            await msd.ShowAsync();
        }
    }
