    public static bool[] chosen = new bool[27];
    public static void cardSelect()
        {
            if (chosen[n] == false && chosen.Count(a => a == true) < 10)
            {
                chosen[n] = true;
            }
            else if (chosen[n] == true)
            {
                chosen[n] = false;
            }
        }
