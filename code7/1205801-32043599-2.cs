    public class Values
    {
        public int Count;
        public readonly HashSet<int> Rows = new HashSet<int>();  //list with rows numbers.
        /// <summary> Add new occurence  </summary>
        /// <param name="rowNumber">Number of row, where occurance</param>
        public void Increment(int rowNumber)
        {
            ++Count;
            Rows.Add(rowNumber);
        }
    }
