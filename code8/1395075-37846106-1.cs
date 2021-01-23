    public Tuple<string,string> GetRowMinAndMax(List<string> colRows)
    {
       var rowLow = colRows.Min(ExtractRow);
        var rowMax = colRows.Max(ExtractRow);
        var col = ExtractCol(colRows.First());
        return Tuple.Create(col + rowLow, col + rowMax);
    }
    public int ExtractRow(string colRow)
    {
      return int.Parse(new string(colRow.Where(char.IsDigit).ToArray()));
    }
    public string ExtractCol(string colRow)
    {
        return new string(colRow.Where(char.IsLetter).ToArray());
    }
