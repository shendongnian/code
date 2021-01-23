    // Class to storage result
    public class Values
    {
        public int Count;   // count of proportion entry.
        public readonly HashSet<int> Rows = new HashSet<int>();  //list with rows numbers.
        /// <summary> Add new proportion</summary>
        /// <param name="rowNumber">Number of row, where proportion entries</param>
        public void Increment(int rowNumber)
        {
            ++Count;    // increase count of proportions entries
            Rows.Add(rowNumber);   // add number of row, where proportion entry
        }
    }
