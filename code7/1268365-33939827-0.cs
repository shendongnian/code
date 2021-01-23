    List<bool[]> list = new List() { T1, T2, T3, T4, T5, T6 }; // add all your arrays, probably generate them in a loop and add them here
    for (int i = 0; i <= 10; i++)
    {
        if (reader.GetInt32(0).ToString() == (i + 10).ToString())
        {
            x = 4; The x-th array you want
            list[x][i] = false;
            list[x][i + 1] = false;
            list[x][i + 2] = false;
            list[x][i + 3] = false;
        }
    }
