        static void Main(string[] args)
        {
            string text = "check this sample";
            char x = GetCommonChar(text);
            Console.WriteLine(x.ToString());
            Console.ReadKey();
        }
        public static char GetCommonChar(string text)
        {
            List<char> myList = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if(!string.IsNullOrWhiteSpace(text[i].ToString()))
                myList.Add(text[i]);
            }
            int fpoint = 0;
            int spoint = 0;
            while (fpoint < myList.Count-1)
            {
               while (spoint < myList.Count-1)
               {
                   if ((myList[fpoint] == myList[spoint + 1]) && (fpoint!=spoint+1))
                       return myList[fpoint];
                   spoint++;
               }
                spoint = 0;
                fpoint++;
            }
            return ' ';
        }
