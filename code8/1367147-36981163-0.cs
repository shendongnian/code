    class Program
    {
        public static List<string> alternativs = new List<string>();
        public static int arrayCount = 23;
        public static int tempCount = 0;
        static void Main(string[] args)
        {
            //this works fast
            string easyInput = "11000011110000000000000";
            //this takes forever
            string hardInput = "11011011011011011011011";
            string TmpVal = "";
            string RevVal = "";
            bool CanAdd;
            alternativs.Add(hardInput);
            while (alternativs.Count > 0)
            {
                CanAdd = false;
                if (alternativs[0].Contains("110"))
                {
                    TmpVal = alternativs[0];
                    RevVal = string.Concat(Enumerable.Reverse(TmpVal)); //String Reverse
                    TmpVal = TmpVal.Replace("110", "001");
                    CanAdd = true;
                }
                if (alternativs[0].Contains("011"))
                {
                    TmpVal = alternativs[0];
                    RevVal = string.Concat(Enumerable.Reverse(TmpVal)); //String Reverse
                    TmpVal = TmpVal.Replace("011", "100");
                    CanAdd = true;
                }
                if (CanAdd == true)
                {
                    if (!alternativs.Contains(TmpVal) && !alternativs.Contains(RevVal))
                    {
                        alternativs.Add(TmpVal);
                    }
                }
                tempCount = alternativs[0].Count(x => x == '1');
                if (tempCount < arrayCount)
                {
                    arrayCount = tempCount;
                }
                alternativs.RemoveAt(0);
            }
            Console.WriteLine(arrayCount);
            Console.ReadLine();
        }
    }
