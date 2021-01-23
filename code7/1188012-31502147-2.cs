    // get all the numbers in the list
    HashSet<int> numbersInTable = new HashSet<int>(dataTable.AsEnumerable().Select(a => (int)a["StationId"]));
            
    // between 1000-9999, find numbers not in the set
    List<int> missingNumbers = Enumerable.Range(1000, 9000).Except(numbersInTable).ToList();
    // convert to a string
    string result = String.Join(Environment.NewLine, missingNumbers.ConvertAll<string>(a => a.ToString()));
            
