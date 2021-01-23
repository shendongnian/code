    List<bool[]> list = new List() { T1, T2, T3, T4, T5, T6 }; // add all your arrays, best generate the arrays in a loop and add them to the list in that loop
    for (int i = 0; i <= 10; i++)
    {
        if (reader.GetInt32(0).ToString() == (i + 10).ToString())
        {
            if(someCondition)
            {
                x = 1; // eg. take the T2 array if condition matches
            }
            else
            {
                x = 2; // eg. take the T3 array if condition does not match
            }
            list[x][i] = false;
            list[x][i + 1] = false;
            list[x][i + 2] = false;
            list[x][i + 3] = false;
        }
    }
