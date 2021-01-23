    private Dictionary<int, IList<int>> _RowAutofitBufferToMergedColsMapping = new Dictionary<int, IList<int>>();
    
    // tells the exporter what column to use as a buffer
    public void RegisterAutofitMapping(int startCol, int stopCol, int bufferCol)
    {
      var mergedCols = Enumerable.Range(startCol, stopCol - startCol + 1).ToList();
    
       if (_RowAutofitBufferToMergedColsMapping.ContainsKey(bufferCol))
          throw new ArgumentException(String.Format("Current worksheet already contains a mapping for buffer column {0}", bufferCol));
    
                _RowAutofitBufferToMergedColsMapping[bufferCol] = mergedCols;
                Worksheet.Column(bufferCol).Width = mergedCols.Sum(item => Worksheet.Column(item).Width + ColumnSeparatorWidth);
    }
    // performs row autofit 
    public void RowAutofit(int rowNo, int startCol, int stopCol, bool merge = true)
    {
       // finding mapping to use for autofit
       IList<int> vals = Enumerable.Range(startCol, stopCol - startCol + 1).ToList();
       String valsStr = String.Join(",", vals);
       var mappingKey = _RowAutofitBufferToMergedColsMapping.Keys.FirstOrDefault(key => vals.SequenceEqual(_RowAutofitBufferToMergedColsMapping[key]));
       if (mappingKey == 0)
          throw new ArgumentException(String.Format("Could not mapping for provided columns - {0}", valsStr));
    
       var range = Worksheet.Worksheet.Range(rowNo, startCol, rowNo, stopCol);
       if (merge)
          range.Merge();
    
        range.Style.Alignment.SetWrapText();
        if (copyStyles)
           ClosedXmlExporter.CopyStyles(this, this, rowNo, startCol, rowNo, mappingKey, CopyStyleOptions.CopyAll());
    
        var sourceValue = Worksheet.Cell(rowNo, startCol).Value;
        Worksheet.Cell(rowNo, mappingKey)
          .SetValue(sourceValue)
          .Style.Alignment.SetWrapText(true);
    
          Worksheet.Column(AutofitDummyCol).AdjustToContents(rowNo, rowNo);
    }
