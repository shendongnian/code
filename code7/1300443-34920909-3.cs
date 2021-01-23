    int chars = 0;
    int words = 0;
    //keep track of spaces so as to only count nonspace-space-nonspace transitions
    //it is initialized to true to count the first word only when we come to it
    bool lastCharWasSpace = true;
    foreach (var c in s)
    {
        chars++;
        if (c == ' ')
        {
            lastCharWasSpace = true;
        }
        else if (lastCharWasSpace)
        {
            words++;
            lastCharWasSpace = false;
        }       
    }
