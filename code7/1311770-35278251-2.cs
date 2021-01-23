    public class CellViewModel
    {
        public double Value { get; set; }
        public int TabIndex { get; set; }
    }
    public IEnumerable<IEnumerable<CellViewModel>> GetMatrix(
        List<List<double>> matrixValues)
    {
        var columnCount = matrixValues.Count;
        return matrixValues
            .Select(x => GetColumn(x, columnCount));
    }
    public IEnumerable<CellViewModel> GetColumn(
        List<double> columnValues,
        int columnCount,
        int columnIndex)
    {
        return columnValues
            .Select((x, i) =>
                new CellViewModel { Value = x, TabIndex = columnIndex + columnCount * i });
    }
