            var visibleRows = myTbl.Rows.Cast<TableRow>().Where(row => row.Visible);
            bool hasEmptyTextBox =
                tableRow.Cells.Cast<TableCell>()
                    .SelectMany(
                        item => item.Controls.Cast<Control>()
                           .Where(cntrl => cntrl.GetType() == typeof(TextBox)))
                    .Any(cntrl => string.IsNullOrEmpty(((TextBox)cntrl).Text));
