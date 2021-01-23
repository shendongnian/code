    static int chosenCount = 0;
    public static void cardSelect()
    {
        if (chosen[n] == false)
        {
            if (chosenCount < 10)
            {
                chosen[n] = true;
                chosenCount++;
            }
            // else show a message maybe?
        }
        else if (chosen[n] == true)
        {
            chosen[n] = false;
            chosenCount--;
        }
    }
