    public class Serie : IEnumerable<decimal>
    {
        List<decimal> mylist = new List<decimal>();
        public decimal this[int index]
        {
            get { return mylist[index]; }
            set { mylist.Insert(index, value); }
        }
        public IEnumerator<decimal> GetEnumerator()
        {
            return mylist.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mylist.GetEnumerator();
        }
        public Serie()
        {
        }
        public Serie(List<decimal> serie)
        {
            mylist = serie;
        }
        public Serie Add(decimal Value)
        {
            mylist.Add(Value);
            return this;
        }
        public double Count()
        {
            return mylist.Count;
        }
        public static Serie operator +(Serie left, decimal right)
        {
            List<decimal> temp = new List<decimal>();
            for (int i = 0; i < left.Count(); i++)
            {
                temp.Add(left[i] + right);
            }
            return new Serie(temp);
        }
    }
