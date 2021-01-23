                    listItems.Add("Date");
                    listItems.Add("Months");
                    listItems.Add("Groceries");
    
                    Microsoft.Office.Interop.Excel.PivotFields pfs = (Microsoft.Office.Interop.Excel.PivotFields)pivot.PivotFields();
    
                    foreach (String s in listItems)
                    {
                        Microsoft.Office.Interop.Excel.PivotField pf = (Microsoft.Office.Interop.Excel.PivotField)pivot.PivotFields(s);
    
                        
    
                        foreach (Microsoft.Office.Interop.Excel.PivotItem item in (Microsoft.Office.Interop.Excel.PivotItems)pf.PivotItems())
                        {
                            if (pf.Value == "Date")
                            {
                                item.ShowDetail = false;
                                break;
                            }
                            if (pf.Value == "Months")
                            {
                                item.ShowDetail = false;
                                break;
                            }
                            if (pf.Value == "Groceries")
                            {
    
                                if (item.Value == "(blank)")
                                {
                                    item.Visible = false;
                                    continue;
                                }
                                item.ShowDetail = false;
                                break;
                                
                            }
                        }
                    }
