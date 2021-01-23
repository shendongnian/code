    public class Node
    {
        public IList<int> ToList()
        {
            var list = new List<int>();
            AddToList(list);
            return list;
        }
        public void AddToList(List<int> list)
        {
            if (left != null)
                left.AddToList(list);
            list.Add(value);
            if (right != null)
                right.AddToList(list);
        }
    }
