    var olvColumn = olv.GetColumn(6); // whichever column you want
    var sb = new StringBuilder();
    foreach (object model in olv.SelectedObjects)
        sb.AppendLine(olvColumn.GetStringValue(model));
    var selectedCellsAsText = sb.ToString();
