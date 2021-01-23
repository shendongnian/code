    private static IEnumerable<object> GetNonNullValuesInColumn(_Application application, _Worksheet worksheet, string columnName)
    {
        // get the intersection of the column and the used range on the sheet (this is a superset of the non-null cells)
        var tempRange = application.Intersect(worksheet.UsedRange, (Range) worksheet.Columns[columnName]);
        // if there is no intersection, there are no values in the column
        if (tempRange == null)
            yield break;
        // get complete set of values from the temp range (potentially memory-intensive)
        var value = tempRange.Value2;
        // if value is NULL, it's a single cell with no value
        if (value == null)
            yield break;
        // if value is not an array, the temp range was a single cell with a value
        if (!(value is Array))
        {
            yield return value;
            yield break;
        }
        // otherwise, the value is a 2-D array
        var value2 = (object[,]) value;
        var rowCount = value2.GetLength(0);
        for (var row = 1; row <= rowCount; ++row)
        {
            var v = value2[row, 1];
            if (v != null)
                yield return v;
        }
    }
