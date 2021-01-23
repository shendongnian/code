    foreach (Cell aCell in aRow.Cells)
                            {
                                switch (aCell.Range.Text.Split(':')[0])
                                {
                                    case "Cell Header Text":
                                        var cellHeaderText= contents.Where(p => p.CellName.Contains("Cell Header Text"));
                                        foreach (var p in cellText)
                                        {
                                            aCell.Range.InsertAfter("\r" + p.CellValue.Replace("\r", string.Empty).Trim() + "\r");
    
                                        }
                                        break;
    
                                    
                                    default:
                                        break;
                                }
    }
