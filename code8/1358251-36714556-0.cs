    foreach (var topTableItem in Database.GetAllWithChildren<TopTable>())
    {
        foreach (var middleTableItem in topTableItem.MiddleTableList)
        {
            System.Diagnostics.Debug.WriteLine(middleTableItem.Id); // The same database entry as in the working code (see below)
            // Fetch MiddleTable children            
            conn.GetChildren(middleTableItem);
            System.Diagnostics.Debug.WriteLine(middleTableItem.BottomTableList.Count); // Always return 0
            foreach (var bottomTableItem in middleTableItem.BottomTableList)
            {
                System.Diagnostics.Debug.Write("It works");
            }
        }
    }
