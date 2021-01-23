     int i = 1;
                foreach (ItemDetailsPrice item in strList)
                {
                    //xlWorkSheet.Cells[i, 0] = new Cell("Code");
                    aRange = (Excel.Range)xlWorkSheet.Cells[i, 1];
                    args[0] = plant;
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                    aRange = (Excel.Range)xlWorkSheet.Cells[i, 2];
                    args[0] = item.ItemCode;
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                    aRange = (Excel.Range)xlWorkSheet.Cells[i, 3];
                    args[0] = item.ItemName;
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                    aRange = (Excel.Range)xlWorkSheet.Cells[i, 4];
                    args[0] = item.ItemPrice;
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                    aRange = (Excel.Range)xlWorkSheet.Cells[i, 5];
                    args[0] = "Y";
                    aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
                    i++;
                }
