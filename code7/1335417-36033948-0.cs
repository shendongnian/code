    DataTable myDataTable = new DataTable();
    myDataTable.Columns.Add("SN", typeof(string));
    string myValues = "-1;1.a;1.b;10;1000;1001;1002;2.c;2.b;2.a;2000;2001;3.a;3.b;3.c;4000;4001;4.a;1.a";
    string[] myValuesArray = myValues.Split(';');
    foreach (string myValue in myValuesArray)
    {
        DataRow myRow = myDataTable.NewRow();
        myRow["SN"] = myValue;
        myDataTable.Rows.Add(myRow);
    }
    string beforeSort = string.Join(";", myDataTable.AsEnumerable().Select(x => x["SN"]));
    Console.WriteLine("Before Sorting:");
    Console.WriteLine(beforeSort);
    IEnumerable<DataRow> sortedValues = myDataTable.AsEnumerable()
                                        //Sort numeric values
                                        .OrderBy(x =>
                                        {
                                            int currentValue = 0;
                                            int.TryParse(x["SN"].ToString(), out currentValue);
                                            if (currentValue > 0)
                                                return currentValue;
                                            else
                                                return 0;
                                        })
                                        //Sort alphanumeric values
                                        .ThenBy(x =>
                                        {
                                            int currentValue = 0;
                                            if (!int.TryParse(x["SN"].ToString(), out currentValue))
                                                return x["SN"].ToString();
                                            else
                                                return string.Empty;
                                        })
                                        //Sort negative values
                                        .ThenBy(x =>
                                        {
                                            int currentValue = 0;
                                            int.TryParse(x["SN"].ToString(), out currentValue);
                                            if (currentValue < 0)
                                                return currentValue;
                                            else
                                                return 0;
                                        });
    string afterSort = string.Join(";", sortedValues.Select(x => x["SN"]));
    Console.WriteLine("After Sorting:");
    Console.WriteLine(afterSort);
    //Copy to your existing datatable
    myDataTable = sortedValues.CopyToDataTable();
