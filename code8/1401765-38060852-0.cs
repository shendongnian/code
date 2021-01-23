      for (int row = ws.Dimension.Start.Row; row <= ws.Dimension.End.Row; row++)
                    {
                        int pos = row % 2;
                        ExcelRow rowRange = ws.Row(row);
                        ExcelFill RowFill = rowRange.Style.Fill;
                        RowFill.PatternType = ExcelFillStyle.Solid;
                        switch (pos)
                        {
                            case 0:
                                RowFill.BackgroundColor.SetColor(System.Drawing.Color.White);
                                
                                break;
                            case 1:
                                RowFill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                                break;
                            
                        }
                    }
