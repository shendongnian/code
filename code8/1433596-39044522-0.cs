    var isFound = false;
    var searchPhrase = "Invalid";
    while (sLine != null)
    {
        sLine = objReader.ReadLine();
        if (sLine != null)
        {
            arrText.Add(sLine);
            if (sLine.Contains(searchPhrase)) isFound = true;
        }
    }
    if (isFound)
    {
        MessageBox.Show("Word Invalid Found");
    }
    else
    {
        MessageBox.Show("Nada");
    }
