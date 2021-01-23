        public static Tuple<int, int> FindTwoSumImprovedNonLinq(IList<int> list, int sum)
        {          
            for (int i = 0; i < list.Count; i++)
            {
                int diff = sum - list[i];
                if (list.IndexOf(diff) > -1)
                    return Tuple.Create(i, list.IndexOf(diff));
            }
            return null;
        }
