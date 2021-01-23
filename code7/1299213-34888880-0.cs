    private static void Save<T>(IQueryable<T> items, IList<IDataWriter> dataWriters, IEnumerable<PropertyColumn> columns) where T : MyTableClass
    {
        int pageSize = 500; //Only 500 records will be loaded.
        int currentStep = 0;
        while (true)
        {
             //Here we create a new request into the database using our filter.                
             var tempList = items.Where(yourFilter).Skip(currentStep * pageSize).Take(pageSize);
             foreach (var item in tempList)
             {
                //If you have an exception here maybe something wrong in your dataWriters or columns.
             }
             currentStep++;
             if (tempList.Count() == 0) //No records have been loaded so we can leave.
                 break;
        }
    }
