    string output = "";//Initialise a variable for all the names to exist inside.
    for(int i = 0; i < names.Length; i++)//For every value in "names"
    {
        output += names[i];//"output" has the newest value of "names" added onto the end.
        if (i < names.Length - 1)//If the name isn't the last one.
        {
            output+= " ";//Add the space.
        }
    }
