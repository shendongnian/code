    string[] st2 = **An Array of up to 10**;
    // If not enough in st2, add from st
    if (st2.Length < 10)
    {
        string[] st = **An Array of up to 10**;
        try
         {
            string[] st3 = new string[10];
            Array.Copy(st2, st3, st2.Length); 
            int index = 0;
            for (int i = st2.Length; i < 10; i++)
            {
                st3[i] = st[index];
                index = index + 1;
            }
            st2 = st3;
         }
         catch (IndexOutOfRangeException)
         {
         }
        }
