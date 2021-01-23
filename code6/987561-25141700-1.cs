                    sheet.DeleteRow(1, 87);
               ====>[HERE]
                    p.SaveAs(new FileInfo(@"output.xlsm"));
    /* Code placed to [HERE] placeholder */
    using (var writer = File.CreateText(@"output.csv"))
                {
                    var rowCount = sheet.Dimension.End.Row;
                    var columnCount = sheet.Dimension.End.Column;
                    for (var r = 1; r <= rowCount; r++)
                    {
                        for (var c = 1; c <= columnCount; c++)
                        {
                            writer.Write(sheet.Cells[r, c].Value);
                            writer.Write(";");
                        }
                        writer.WriteLine();
                    }
                }
