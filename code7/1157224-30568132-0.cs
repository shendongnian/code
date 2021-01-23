    System.IO.StreamWriter file = new System.IO.StreamWriter(path);
    for (int i = 0; true && flag; i++)
    {
        file.WriteLine(some_text_goes_Inside);
        if (i == 200)
        {
            file.Flush();
            i = 0;
        }
    }
    file.Close();
