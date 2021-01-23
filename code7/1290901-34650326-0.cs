                var start = worksheet.Dimension.Start;
                var end = worksheet.Dimension.End;
                for (int row = start.Row; row <= end.Row; row++)
                {
                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        string cellValue = worksheet.Cells[row, col].Text.ToString();
                        if (cellValue == "<<_time>>")
                        {
                            worksheet.Cells[row, col].Value = "..";
                        }
                    }
                }
