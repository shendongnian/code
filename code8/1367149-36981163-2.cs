    class Program
    {
        public static string CurStr;
        public static int arrayCount = 23;
        public static int tempCount = 0;
        static void Main(string[] args)
        {
            //this works fast
            string easyInput = "11000011110000000000000";
            //this takes forever
            string hardInput = "11011011011011011011011";
            string TmpVal = "";
            bool CanAdd;
            CurStr = hardInput;
            CanAdd = true;
            while (CanAdd)
            {
                TmpVal = CurStr;
                CanAdd = false;
                if (TmpVal.Contains("110"))
                {
                    TmpVal = TmpVal.Replace("110", "001");
                    CanAdd = true;
                }
                if (TmpVal.Contains("011"))
                {
                    TmpVal = TmpVal.Replace("011", "100");
                    CanAdd = true;
                }
                if (CanAdd == true)
                {
                    CurStr = TmpVal;
                }
                tempCount = CurStr.Count(x => x == '1');
                if (tempCount < arrayCount)
                {
                    arrayCount = tempCount;
                }
            }
            Console.WriteLine(arrayCount);
            Console.ReadLine();
        }
    }
