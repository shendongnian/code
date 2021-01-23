    for (int i = 0; i < Board.Length - 2; i++)
    {
        string a = (string)Board[i].Content;
        string b = (string)Board[i + 1].Content;
        string c = (string)Board[i + 2].Content;
        if (a == b && a == c &&
            a != string.Empty && a != null)
        {
            MessageDialog msd = new MessageDialog("test");
            await msd.ShowAsync();
        }
    }
