        static void Main(string[] args)
        {
            string st = "abc+{(a,b,c),(d,e,f),(r,s,t),(u,v,y)}+test-{(a,b),(c,d,e)}+rst+{(a,b),(c,d)}";
            int possibleCountTuple = st.Length / 2;
            for(int i = 1; i<possibleCountTuple; i++)
            {
                TestStringForTuple(st,i);
            }
            Console.ReadLine();
        }
        private static void TestStringForTuple(string str,int order)
        {
            Regex oRegex = new Regex(@"{((.{"+order+"}),(.{"+order+"}))}");
            foreach (Match mt in oRegex.Matches(str))
            {
                Console.WriteLine(mt.Value);
            }
        }
