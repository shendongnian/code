    public IEnumerable<StructuredCell> Cells(){
        for (int i = 0; i < maxColumn; i++)
            {
                Dictionary<int, StructuredCell> row = null;
                CellValues.TryGetValue(i, out row);
                for (int j = 0; j < maxRow; j++)
                {
                    if (row == null) yield return null;
                    StructuredCell cell = null;
                    row.TryGetValue(j, out cell);
                    yield return cell;
                }
            }
    }
