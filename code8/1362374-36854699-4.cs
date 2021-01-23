            var tableRows = Table1.Rows.Cast<TableRow>().Where(row => row.Visible);
            bool hasEmptyField = false;
            foreach (var row in tableRows.Where(row => row.Cells.Cast<TableCell>()
                .SelectMany(
                    item => item.Controls.Cast<Control>()
                        .Where(cntrl => cntrl.GetType() == typeof (TextBox)))
                .Any(cntrl => string.IsNullOrEmpty(((TextBox) cntrl).Text))))
            {
                hasEmptyField = true;
                break;
            }
            if (hasEmptyField)
            {
                //Do what you want...
            }
