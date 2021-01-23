    public void inputRowData(string[] data, int rds)
    {
        int bestRow = getRowByRDS(rds);
        string val = getValueOfCell(bestRow, 6);
        if (val == null || val.Equals(""))
        {
            shiftRows(bestRow, data.Length);
            string[] formatedData = formatOutput(bestRow, data);
            // transform formated data into string[,]
            var string[][] splitedData = formatedData.Select(s => s.Split('\t')).ToArray();
            var colCount = splitedData.Max(r => r.Lenght);
            var excelData = new string[splitedData.Length, colCount]
            for (int i = 0; i < splitedData.Length; i++)
            {
                for (int j = 0; j < splitedData[i].Length; j++)
                {
                     excelData[i,j] = splitedData[i][j];
                }
            }
            oSheet.get_Range("A" + bestRow.ToString()).Resize(splitedData.Length, colCount).Value = excelData;
        }
        else
        {
            Console.WriteLine("Line has some information already, skipping 1 more");
            shiftRows(bestRow, data.Length + 1);
        }
    }
