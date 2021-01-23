    public static bool[] chosen = new bool[27];
    public static void cardSelect()
        {
            var trueCount = chosen.Where(a => a == true).Count();
            if (chosen[n] == false && trueCount < 10)
            {
                chosen[n] = true;
            }
            else if (chosen[n] == true)
            {
                chosen[n] = false;
            }
        }
