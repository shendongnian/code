    public class FrigoriferoClassColumn
    {
        List<string> _rowValues = new List<string>(); 
        public FrigoriferoClassColumn(List<string> rowValues) {
            _rowValues = rowValues;
        }
        public string this[int column] {
            get {
                return _rowValues[column];
            }
        }
    }
