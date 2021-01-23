    static void Main(string[] args)
    {
        double dParseSettleMM;
        int iParseOpen;
        int iParseBuy;
        int iParseSell;
        string sUnderlyingControl = string.Empty;
        string sUnderlying = string.Empty;
        string sAccount = string.Empty;
        string sAccountControl = string.Empty;
        var path = @"C:\Users\jhochbau\documents\visual studio 2015\Projects\CsvReader\CSVReaderList\Position_2016_02_25.0415.csv";
        Dictionary<string, List<DataRecord>> vSummaryResults = new Dictionary<string, List<DataRecord>>();
        //Sets up control to switch between sorted lists.
        Console.WriteLine("Enter 1 to sort by Account, 2 to sort by Underlying, 3 to sort by Account and Underlying");
        string control = Console.ReadLine();
        //open reader
        StreamReader r = new StreamReader(path);
        StreamWriter vWriteFile = new StreamWriter("Positions2.csv");
        //Consume first line
        r.ReadLine();
        //While loop to populate List with record Objects
        while (!r.EndOfStream)
        {
            DataRecord records = new DataRecord();
            var line = r.ReadLine();
            var values = line.Split(',');
            //Need to add into dictionary...
            if (vSummaryResults.ContainsKey(records.account))
            {
                vSummaryResults[records.account].Add(record);
            }
            else
            {
                vSummaryResults.Add(records.account, new List<DataRecord>();
                vSummaryResults[records.account].Add(record);
            }
        }
    }
