        class Data
        {
            public int C1 { get; set; }
            public int C2 { get; set; }
            public int C3 { get; set; }
        }
    
        class Program
        {
            static Queue<Data> RowsDataQueue = new Queue<Data>();
            static void Main(string[] args)
            {
                ThreadStart testThreadStart11 = new ThreadStart(excelwriter);
                Thread testThread11 = new Thread(testThreadStart11) { IsBackground = true };
                testThread11.Start();
                while (true)
                {
                    Data RowData = ReadDataFromSomeWhere();
                    RowsDataQueue.Enqueue(RowData);
                }
            }
    
            public static void excelwriter()
            {
                while (true)
                {
                    if (RowsDataQueue.Count > 0)
                    {
                        Data D = RowsDataQueue.Dequeue();
                        //write values in the D to the excel file...
                    }
                }
            }
    
            private static Data ReadDataFromSomeWhere()
            {
                throw new NotImplementedException();
            }
        }
