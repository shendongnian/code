        public static void Main()
        {
            List<PatternInfo> patternlist = null;
            for (int i = 0; i < 10; i++)
                patternlist.Add(new PatternInfo(i.ToString(), i));
            foreach(PatternInfo x in patternlist)
            {
                string a = x.prpatternname;
                int b = x.prpatterntier;
            }
            
        }
