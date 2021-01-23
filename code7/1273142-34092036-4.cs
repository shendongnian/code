    ArrayList array_2008 = new ArrayList();
    ArrayList array_2009 = new ArrayList();
    ArrayList array_2010 = new ArrayList();
    ArrayList array_2011 = new ArrayList();
    ArrayList array_2012 = new ArrayList();
    
    for (int i = 0; i < arrayList1.Count; i++)
    {
        var aIndex = getIndex(arrayList1[i].ToString());
        if (arrayList1[i].ToString().Contains("2008"))
        {
            array_2008.Add( new List<object>()
            {
                aIndex, arrayList1[i].ToString() 
            });
        }
        if (arrayList1[i].ToString().Contains("2009"))
        {
            array_2009.Add( new List<object>()
            {
                aIndex, arrayList1[i].ToString() 
            });
        }
        else if (arrayList1[i].ToString().Contains("2010"))
        {
            array_2010.Add(new List<object>()
            {
                aIndex, arrayList1[i].ToString() 
            });
        }
        else if (arrayList1[i].ToString().Contains("2011"))
        {
            array_2011.Add(new List<object>()
            {
                aIndex, arrayList1[i].ToString() 
            });
        }
        else if (arrayList1[i].ToString().Contains("2012"))
        {
            array_2012.Add(new List<object>()
            {
                aIndex, arrayList1[i].ToString() 
            });
        }
    }
