                foreach (Range cell in row.Cells)
                {
                    if (cell.Column == 1) Temp1 = Temp1.Replace("<Status>", cell.Text);
                    if (cell.Column == 2) Temp1 = Temp1.Replace("<NName>", cell.Text);
                    if (cell.Column == 3) Temp1 = Temp1.Replace("<Notes>", cell.Text);
                }
