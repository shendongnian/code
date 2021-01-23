    public class YourClass
    {
        public Dictionary<string, int> YourProperty...
    
         public static Dictionary<string, int> operator / ( YourClass first, Dictionary<string, int> second )
        {
            // Returns all elements in first but not second, where the number in the first but not second
            // for a given key is the first's value minus the second's value
            Dictionary<string, int> firstNotSecond = new Dictionary<string, int>();
            foreach ( KeyValuePair<string, int> pair in first.YourProperty )
            {
                int secondNum = second.ContainsKey(pair.Key) ? second[pair.Key] : 0;
                if ( pair.Value > secondNum )
                {
                    firstNotSecond[pair.Key] = pair.Value - secondNum;
                }
            }
            return firstNotSecond;
        }
    }
   
