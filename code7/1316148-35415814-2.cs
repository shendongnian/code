    // implement INPC for notifications, but I won't show it for brevity
    public class SizeColumn : INotifyPropertyChanged
    {
        public string Header { get; set; }
        public int Count { get; set; }
        public int Index { get; set; }
    }
    class StyleGridRow
    {
        // ...
        public ObservableCollection<SizeColumn> SizeColumns { get; set; }
        // ...
    }
    // ...
    int index = 0;
    var sizeColumns = new List<SizeColumn>();
    // TODO: Refactor `Select().Distinct()` this so all rows will have same order and length
    var sizes = Items.Select(i => i.Size).Distinct().ToList();
    foreach (string s in sizeColumns)
    {
        // Assuming you are summing the values, and the property name is `Value`
        var count = Items.Where(x => x.Size == s).Sum(i => i.Value);
        sizeColumns.Add(new SizeColumn()
        {
            Header = s,
            Count = count,
            Index = index,
        });
        columns.Add(new DataGridTextColumn()
        {
            Header = s,
            Binding = new Binding(string.Format("SizeColumns[{0}].Count", index)),
        });
        ++index;
    }
    SizeColumns = new ObservableCollection<SizeColumn>(sizeColumns);
    ColumnCollection = new ObservableCollection<DataGridColumn>(columns);
