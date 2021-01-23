    public void TestList()
    {
        cvList.Add(new ColumnAndValue(){ColumnName = "Column 1", ColumnValue = "Value 1"});
        cvList.Add(new ColumnAndValue(){ColumnName = "Column 2", ColumnValue = "Value 2"});
        cvList.Add(new ColumnAndValue(){ColumnName = "Column 3", ColumnValue = "Value 3"});
        cvList.Add(new ColumnAndValue(){ColumnName = "Column 4", ColumnValue = "Value 4"});
    
        List<string> c1 = cvList.Select(c => c.ColumnName).ToList();
    
        foreach (object obj in c1)
        {
            Console.WriteLine(obj.ToString());
        }
    
    }
