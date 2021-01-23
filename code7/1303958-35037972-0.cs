    for (var i = 0; i < data.Length; i++)
    {
        var tr = new TableRow();
        for (var j = 0; j < data[i].Length; j++)
        {
            var tc = new TableCell();
            tc.Append(new TableCellProperties(new TableCellWidth() 
                                                 { Type = TableWidthUnitValues.Auto }));
            Paragraph para = new Paragraph(runTools.getRun(16, "Tahoma", new Text(data[i][j])));
            if (data[i].Length == 1)
            {
                //add a GridSpan with a value of 2 so this cell spans across 2 columns
                tc.TableCellProperties.AppendChild(new GridSpan() { Val = 2 });
                //center justify the text
                if (para.ParagraphProperties == null)
                    para.ParagraphProperties = new ParagraphProperties();
                para.ParagraphProperties.Justification = new Justification()
                                                            { Val = JustificationValues.Center };
            }
            tc.Append(para);
            tr.Append(tc);
        }
        table.Append(tr);
    }
