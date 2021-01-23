    Novacode.Table table = document.Tables[0]
    Novacode.Row row = table.Rows[0];
    int first_cell = 0;
    int last_cell = 1;
    for(int i = first_cell; i < last_cell + 1; i++)
    {
        foreach (var paragraph in r.Cells[i].Paragraphs)
        {
            paragraph.Remove(false);
        }
    }
    row.MergeCells(first_cell, last_cell);
    Novacode.Cell cell = row.Cells[first_cell];
    Novacode.Border border = new Border();
    border.Tcbs = Novacode.BorderStyle.Tcbs_none;
    cell.SetBorder(Novacode.TableCellBorderType.Right, border);
    cell.SetBorder(Novacode.TableCellBorderType.Left, border);
    cell.SetBorder(Novacode.TableCellBorderType.Top, border);
    cell.SetBorder(Novacode.TableCellBorderType.Bottom, border);
