    public void TestList()
    {
        ColumnAndValue cv = new ColumnAndValue();
        cv.ColumnName = "Column 1";
        cv.ColumnValue = "Value 1";
        cvList.Add(cv);
        // Now cv is a reference to a different object
        cv = new ColumnAndValue();
        cv.ColumnName = "Column 2";
        cv.ColumnValue = "Value 2";
        cvList.Add(cv);
        // Now cv is a reference to a different object
        cv = new ColumnAndValue();
        cv.ColumnName = "Column 3";
        cv.ColumnValue = "Value 3";
        cvList.Add(cv);
        // Now cv is a reference to a different object
        cv = new ColumnAndValue();
        cv.ColumnName = "Column 4";
        cv.ColumnValue = "Value 4";
        cvList.Add(cv);
        List<string> c1 = new List<string>();
        c1 = cvList.Select(c => c.ColumnName).ToList();
        foreach (object obj in c1)
        {
            Console.WriteLine(obj.ToString());
        }
    }
