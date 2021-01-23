	DataTable myDataTable = new DataTable();
	myDataTable.Columns.Add("SN", typeof(string));
	//string myValues = "-1;1.a;1.b;10;1000;1001;1002;2.c;2.b;2.a;2000;2001;3.a;3.b;3.c;4000;4001;4.a;1.a";
	string myValues = "a;a.b;c.c;-1;1.a;1.a;1.b;10;11.a;11.b;13.a;2.a;2.b;2.c;21.a;22.b;3.a;3.b;3.c;4.a;1000;1001;1002;2000;2001;4000;4001";
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
										.OrderBy(x =>
										{
											string currentStringValue = x["SN"].ToString();
											string[] currentStringValueArray = currentStringValue.Split('.');
											if (currentStringValueArray.Length == 2)
											{
												string currentPart = "";
												int currentPartNumeric = 0;
												if (int.TryParse(currentStringValueArray[0], out currentPartNumeric))
												{
													currentPart += currentPartNumeric.ToString();
												}
												else
												{
													//We are assuming our alphanumeric chars are integers
													currentPart += (((int)(char.ToUpper(char.Parse(currentStringValueArray[0])))) - 64).ToString();
												}
												if (int.TryParse(currentStringValueArray[1], out currentPartNumeric))
												{
													currentPart += "." + currentPartNumeric.ToString();
												}
												else
												{
													//We are assuming our alphanumeric chars are integers
													currentPart += "." + (((int)(char.ToUpper(char.Parse(currentStringValueArray[1])))) - 64).ToString();
												}
												return Convert.ToDecimal(currentPart, CultureInfo.InvariantCulture);
											}
											else if (currentStringValueArray.Length == 1)
											{
												int currentPartNumeric = 0;
												string currentPart = "";
												if (int.TryParse(currentStringValueArray[0], out currentPartNumeric))
												{
													currentPart += currentPartNumeric.ToString();
												}
												else
												{
													//We are assuming our alphanumeric chars are integers
													currentPart += "." + (((int)(char.ToUpper(char.Parse(currentStringValueArray[0])))) - 64).ToString();
												}
												return Convert.ToDecimal(currentPart, CultureInfo.InvariantCulture);
											}
											else
												return 0m;
										});
	string afterSort = string.Join(";", sortedValues.Select(x => x["SN"]));
	Console.WriteLine("After Sorting:");
	Console.WriteLine(afterSort);
	//Copy to your existing datatable
	myDataTable = sortedValues.CopyToDataTable();
