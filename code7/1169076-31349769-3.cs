    Novacode.Table table = document.Tables[0]
    Novacode.Row row = table.Rows[0]; //int of row that contains cell/cells to remove
    int first_cell = 0; //beginning cell of range
    int last_cell = 1; //last cell of range
    for(int i = first_cell; i < last_cell + 1; i++)
    {
        foreach (var paragraph in row.Cells[i].Paragraphs)
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
