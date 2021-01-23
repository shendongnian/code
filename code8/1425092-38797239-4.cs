    public class TwoRows
    {
        public DataRow Row1 { get; set; }
        public DataRow Row2 { get; set; }
    }
    private static List<TwoRows> LeftOuterJoin(
        List<string> joinColumnNames,
        DataTable leftTable,
        DataTable rightTable)
    {
        return leftTable
            .AsEnumerable()
            .GroupJoin(
                rightTable.AsEnumerable(),
                l => l,
                r => r,
                (l, rlist) => new {LeftValue = l, RightValues = rlist},
                new MyEqualityComparer(joinColumnNames.ToArray()))
            .SelectMany(
                x => x.RightValues.DefaultIfEmpty(rightTable.NewRow()),
                (x, y) => new TwoRows {Row1 = x.LeftValue, Row2 = y})
            .ToList();
    }
