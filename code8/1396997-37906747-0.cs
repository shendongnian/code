    List<myRecordClass> myResults = new List<myRecordClass>();
                
    for (int i = 1; i < myTable.Count; i++)
        {
            if (myTable.ElementAt(i).Action == myTable.ElementAt(i-1).Action)
            {
                myResults.Add(myTable.ElementAt(i - 1));
                myResults.Add(myTable.ElementAt(i));
            }
        }
