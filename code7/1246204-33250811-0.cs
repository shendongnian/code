    public static Dictionary<string, int> Letters(string a)
    {
        Dictionary<string, int> letters = new Dictionary<string, int>();
        string p = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ"; // Lithuanian letters
        int ind = -1;
        foreach (char r in a)
        {
            ind = p.IndexOf(r);
            if (ind >= 0)
            {
                if (letters.ContainsKey(r.ToString()))
                {
                    letters[r.ToString()] = letters[r.ToString()] + 1;
                }
                else
                {
                    letters.Add(r.ToString(), 1);
                }
            
            }
        }
        return letters;
    }
