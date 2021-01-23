    var activeSheet = (Worksheet) Globals.ThisAddIn.Application.ActiveSheet;
                int lastUsedCell = activeSheet.UsedRange.Rows.Count;
    //in this example we dynamicly add drop down list to second colomn
                string columnName = "B" + lastUsedCell;
    //the range is from second colomn of first row to last row          
          Range range = activeSheet.Range["B1", columnName];
       var list=new List<string>();
                        list.Add("a");
                        list.Add("b");
                        string items= string.Join(",",
                            list);
                        range.Validation.Add(XlDVType.xlValidateList, Type.Missing,
                            XlFormatConditionOperator.xlBetween, items);
                        InsertingTypeNotificationLable.Visible = true;
                        SendButton.Enabled = true;
