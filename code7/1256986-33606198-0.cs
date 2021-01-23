    void RemoveDates(DataTable dataTable, int countToKeep)
    { 
        var indexesToKeep = IndexesToKeep(dataTable.Rows.Count, countToKeep);
        for (var i = 0; i < dataTable.Rows.Count; ++i)
        {
            if (!indexesToKeep.Contains(i))
            {
                dataTable.Rows[i]["DateString"] = "";
            }
        }
    }
    
    HashSet<int> IndexesToKeep(int totalCount, int countToKeep)
    {
        var keep = new HashSet<int>();
        for (var i = 0; i < totalCount - 1 && keep.Count < countToKeep; i += totalCount / (countToKeep - 1))
        {
            keep.Add(i);
        }
        keep.Add(totalCount - 1);
        return keep;
    }
