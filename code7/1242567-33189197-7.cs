    public static Rows ToRows(this IEnumerable<dynamic> enumerable)
    {
        return
            new Rows(
                enumerable
                    .Cast<IEnumerable<KeyValuePair<string, object>>>()
                    .Select(row =>
                        new Row(row.Select(cell => new Cell(cell)))));
    }
