    IEnumerable<MySummarizedRow> GetSummarizedRows()
    {
        using (var entries = GetRowsOrderedByDocIdAndRowId().GetEnumerator())
        {
            if (entries.MoveNext())
            {
                var previous = entries.Current;
                while (entries.MoveNext())
                {
                    var current = entries.Current;
                    if (current.DocId == previous.DocId)
                        yield return new MySummarizedRow(previous.DepartmentId, current.DocId, current.Time.Substract(previous.Time).TotalDays + 1);
                    previous = current;
                }
            }
        }
    }
