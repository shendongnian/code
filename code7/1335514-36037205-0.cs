    public class DataStructure {
        private const int MAX_VALUE = 100000;
        private readonly Dictionary<long, StructuredCell> CellValues;
        private void Add(int keyOne, int keyTwo, StructuredCell cell) {
            long hashKey = keyOne*MAX_VALUE + keyTwo;
            CellValues[hashKey] = cell;
        }
        private void Remove(int keyOne, int keyTwo)
        {
            long hashKey = keyOne * MAX_VALUE + keyTwo;
            CellValues.Remove(hashKey);
        }
        private IEnumerable<StructuredCell> GetCells() {
            return CellValues.Values;
        }
    }
