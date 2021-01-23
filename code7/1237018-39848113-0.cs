        public static IList<Tuple<int,int>> GetCombination(IList<int> values)
        {
            List<Tuple<int,int>> _temp=new List<Tuple<int, int>>();
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < values.Count; j++)
                {
                    if (i != j)
                    {
                        _temp.Add(Tuple.Create(i, j));
                    }
                }
            }
            return _temp;
        }
        
