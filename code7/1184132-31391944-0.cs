    public abstract class ExcelParser
    {
        protected FileInfo fileInfo { get; set; }
    
        protected bool FileIsValidExcelFile()...
        protected virtual string GetCellValue(int row, int column)...
        protected virtual int GetColumnLocation(string columnHeader)...
    
        public abstract IEnumerable<T> Parse<T>();
    }
    
