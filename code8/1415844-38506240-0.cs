    public class SumOfAmounts
    {
        private FileRow _fileRow;
        private WSRow _webRow;
        public int Sum { get; set; }
        public SumOfAmounts(FileRow filerow, WSRow webrow)
        {
            _fileRow = filerow;
            _webRow = webrow;
            
            Sum = _fileRow.AMOUNT + _webRow.AMOUNT;
        }
    }
