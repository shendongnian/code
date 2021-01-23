    var builder = new StringBuilder();
    firstCheckedRow.Cells.Cast<DataGridViewCell>()
                   .ToList().ForEach(cell =>
                   {
                       builder.AppendLine(string.Format("{0}", cell.Value));
                   });
