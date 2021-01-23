                var grouped = tp.GroupBy(o => o);
                var groupedLength = grouped.Max(o => o.Count());
                for (int l = 0; l < groupedLength; l++)
                {
                    worksheet.Cells[10 + l, 1] = vol[l];
                    foreach (var tbItem in grouped)
                    {
                        if (tbItem.Count() > l)
                        {
                            if (tbItem.Key == "t1")
                                worksheet.Cells[10 + l, 2] = tbItem.ElementAt(l);
                            if (tbItem.Key == "t2")
                                worksheet.Cells[10 + l, 3] = tbItem.ElementAt(l);
                            if (tbItem.Key == "t3")
                                worksheet.Cells[10 + l, 4] = tbItem.ElementAt(l);
                        }
                    }
                }
 
