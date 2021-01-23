    while(!movelist.EndOfStream)
    {
        comboBox_Movelist.Items.Add(line);
        line = movelist.ReadLine();
    }
