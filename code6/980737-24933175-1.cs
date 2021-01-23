    public struct Alignment
    {
        public string substringA;
        public string substringB;
        public int key;
    }
    [MTAThread]
    static void Main(string[] args)
    {
        //This has been assumed that the strings contain only A,C,G,T and -(?)..caps
        Console.WriteLine("Enter first string : ");
        var a = Console.ReadLine();
        a = "-" + a;
        Console.WriteLine("Enter second string : ");
        var b = Console.ReadLine();
        b = "-" + b;
        Alignment[,] SQ = new Alignment[a.Length, b.Length];
        #region Create Dictionary
        ...
        #endregion Create Dictionary
        for (int i = 0; i < a.Length; i++)
        {
            for (int j = 0; j < b.Length; j++)
            {
                int key = 0, key1 = 0, key2 = 0;
                dict.TryGetValue(a[i].ToString() + b[j].ToString(), out key);
                dict.TryGetValue("-" + b[j].ToString(), out key1);
                dict.TryGetValue(a[i].ToString() + "-", out key2);
                if (i == 0)
                {
                    SQ[i, j].substringA = "-";
                    SQ[i, j].substringB = b[j].ToString();
                    SQ[i, j].key = key1;
                }
                else if (j == 0)
                {
                    SQ[i, j].substringA = a[i].ToString();
                    SQ[i, j].substringB = "-";
                    SQ[i, j].key = key2;
                }
                else
                {
                    // Get the maximum key value, and the substrings associated with it.
                    int score;
                    var score1 = SQ[i - 1, j].key + key1;
                    var score2 = SQ[i, j - 1].key + key2;
                    if (score1 >= score2)
                    {
                        SQ[i, j].substringA = SQ[i - 1, j].substringA;
                        SQ[i, j].substringB = SQ[i - 1, j].substringB;
                        score = score1;
                    }
                    else
                    {
                        SQ[i, j].substringA = SQ[i, j - 1].substringA;
                        SQ[i, j].substringB = SQ[i, j - 1].substringB;
                        score = score2;
                    }
                    var score3 = SQ[i - 1, j - 1].key + key;
                    if (score3 >= score)
                    {
                        SQ[i, j].substringA = SQ[i - 1, j - 1].substringA;
                        SQ[i, j].substringB = SQ[i - 1, j - 1].substringB;
                        score = score3;
                    }
                    SQ[i, j].substringA += a[i];
                    SQ[i, j].substringB += b[j];
                    SQ[i, j].key = score;
                }
            }
        }
        PrintAlignments(SQ, a.Length, b.Length);
        Console.WriteLine("Alignment Score : " + SQ[a.Length - 1, b.Length - 1].key);            
        Console.Read();
    }
    private static void PrintAlignments(Alignment[,] SQ, int iLength, int jLength)
    {
        for (int i = 0; i < iLength; i++)
        {
            for (int j = 0; j < jLength; j++)
            {
                Console.WriteLine("{0} {1}", SQ[i, j].substringA, SQ[i, j].key);
                Console.WriteLine("{0}", SQ[i, j].substringB);
                Console.WriteLine();
            }
        }
    }
