    public void ReadText()
    {
        string line = ...; // However you read a line
        string[] patron = line.Split(':');
        idNum = patron[0];
        ...
    }
