    public class Item
    {
        public Item(int _val, int _loc) {
            val = _val;
            loc = _loc;
        }
        public int val;
        public int loc;
    }
    class TwoSum
    {
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            Tuple<int, int> result = null;
            Dictionary<int, Item> dictionary = new Dictionary<int, Item>();
            int index = 0; 
            bool done = false;
    
            do
            {
                int curr = list[index];
                int pair = sum - list[index];
    
                if (dictionary.ContainsKey(pair))
                {
                    result = new Tuple<int, int>(index, dictionary[pair].loc);
                    done = true;
                }
                else
                {
                    if (! dictionary.ContainsKey(curr))
                    {
                        Item found1 = new Item(curr, index);
                        dictionary.Add(curr, found1);
                    }
                }
                index++;
            }
            while (index < list.Count && !done);
            return result;
        }
