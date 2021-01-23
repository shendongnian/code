                var uniqueList = dt.AsEnumerable().Select(x => x.Field<string>("ProdType")).Distinct();
                List<string> myList = new List<string>();
                myList = uniqueList.ToList();
                DataTable[] array = new DataTable[myList.Count()];
                int index = 0;
                foreach (string item in myList)
                {
                    var Result = from x in dt.AsEnumerable()
                                 where x.Field<string>("ProdType") == item
                                 select x;
                    DataTable table = Result.CopyToDataTable();
                    array[index] = table;
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(item);
                    ws.Cells["A1"].LoadFromDataTable(table, true);
                    index++;
                }
