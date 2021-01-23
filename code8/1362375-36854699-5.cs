            var tableRow = Table1.Rows.Cast<TableRow>().Last(row => row.Visible);
            var hasEmptyTextBox =
                tableRow.Cells.Cast<TableCell>()
                    .SelectMany(
                        item => item.Controls.Cast<Control>()
                            .Where(cntrl => cntrl.GetType() == typeof(TextBox)))
                    .Any(cntrl => string.IsNullOrEmpty(((TextBox)cntrl).Text));
