    using System.Linq;
    public static void cardSelect()
    {
        if (chosen[n] == false)
        {
             if (chosen.Count(c => c) < 10)
             {
                chosen[n] = true;
             }
        }
        else if (chosen[n] == true)
        {
            chosen[n] = false;
        }
    }
