    int count = 0;
    while (!CSVFile2.EndOfData)
    {
        if (!badCustomers.ContainsKey(dataArray2[0]))
        {
            String record = String.Empty;
            for(int i = 0; i < dataArray2.Length; i++)
            {
                if (dataArray2[i].Contains(","))
                {
                     string x = "\"" + dataArray2[i] + "\"";
                     record += x;
                }
                else
                {
                     record += dataArray2[i];
                } 
                if (i < dataArray.Length -1)
                {
                      record += ",";
                }
            }
            count++;
            if( count % 50 == 0)
            {
                Console.WriteLine(count);
            }
            output.WriteLine(record);
        }
        dataArray2 = CSVFile2.ReadFields();
    }
