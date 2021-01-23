    public struct Values
    {
        public int Count;
        public HashSet<int> Rows;  //list with rows numbers.
        /// <summary> Add new occurence  </summary>
        /// <param name="rowNumber">Number of row, where occurance</param>
        public void Increment(int rowNumber)
        {
            ++Count;
            Rows.Add(rowNumber);
        }
    }
