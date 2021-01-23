    class Program
    {
        static Dictionary<string, int> dict;
        static void printAllAlignments(int[,] SQ, string a, string b, int p, int q, string str1, string str2){
            if (p == 0 || q == 0){
                while (p == 0 && q != 0){
                    str1 = "-" + str1;
                    str2 = b[--q]+str2;
                }
                while (q == 0 && p != 0){
                    str1 = a[--p]+str1;
                    str2 = '-' + str2;
                }
                Console.WriteLine("\n"+str1+"\n"+str2+"\n");
                return;
            }
            if (SQ[p, q] == (dict[a[p - 1] + b[q - 1].ToString()] + SQ[p - 1, q - 1]))
                printAllAlignments(SQ, a, b, p - 1, q - 1, a[p-1]+str1, b[q-1]+str2);
            if (SQ[p, q] == (dict[a[p - 1]+ "-"] + SQ[p - 1, q]))
                printAllAlignments(SQ, a, b, p - 1, q, a[p-1]+str1, "-"+str2);
            
            if (SQ[p, q] == (dict["-" + b[q-1]] + SQ[p, q - 1]))            
                printAllAlignments(SQ, a, b, p, q - 1, "-"+str1, b[q-1]+str2);
            
        }
        static void Main(string[] args)
        {
            //This has been assumed that the strings contain only A,C,G,T and -(?)..caps
            Console.WriteLine("Enter first string : ");
            string a = Console.ReadLine();         
            Console.WriteLine("Enter second string : ");
            string b = Console.ReadLine();          
            int[,] SQ = new int[a.Length+1, b.Length+1];
            #region Create Dictionary
            dict = new Dictionary<string, int>();
            dict.Add("AA", 5);
            dict.Add("AC", -1);
            dict.Add("AG", -2);
            dict.Add("AT", -1);
            dict.Add("A-", -3);
            dict.Add("CA", -1);
            dict.Add("CC", 5);
            dict.Add("CG", -3);
            dict.Add("CT", -2);
            dict.Add("C-", -4);
            dict.Add("GA", -2);
            dict.Add("GC", -3);
            dict.Add("GG", 5);
            dict.Add("GT", -2);
            dict.Add("G-", -2);
            dict.Add("TA", -1);
            dict.Add("TC", -2);
            dict.Add("TG", -2);
            dict.Add("TT", 5);
            dict.Add("T-", -1);
            dict.Add("-A", -3);
            dict.Add("-C", -4);
            dict.Add("-G", -2);
            dict.Add("-T", -1);
            dict.Add("--", 0);
            #endregion Create Dictionary
            SQ[0, 0] = 0;            
            for (int i = 1; i <= a.Length; i++)            
                SQ[i, 0] = dict["-" + a[i - 1].ToString()] + SQ[i - 1, 0];
            for (int i = 1; i <= b.Length; i++)
                SQ[0, i] = dict[b[i - 1].ToString() + "-"] + SQ[0, i - 1];
            
            for (int i = 1; i <= a.Length; i++)
                for (int j = 1; j <= b.Length; j++)
                    SQ[i, j] = Math.Max(SQ[i - 1, j - 1] + dict[a[i-1].ToString() + b[j-1]], Math.Max(SQ[i - 1, j] + dict[a[i-1] + "-"], SQ[i, j - 1] + dict["-" + b[j-1]]));           
            
            Console.WriteLine("Max Alignment Score : " + SQ[a.Length, b.Length]);
            printAllAlignments(SQ, a, b, a.Length , b.Length,"","");
            Console.Read();
        }
    }
