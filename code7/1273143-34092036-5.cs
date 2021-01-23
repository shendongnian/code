    var array_2008 = new List<object>() {0, string.Empty};
    var array_2009 = new List<object>() {0, string.Empty};
    var array_2010 = new List<object>() {0, string.Empty};
    var array_2011 = new List<object>() {0, string.Empty};
    var array_2012 = new List<object>() {0, string.Empty};
    for (int i = 0; i < arrayList1.Count; i++)
    {
        var aIndex = getIndex(arrayList1[i].ToString());
        if (arrayList1[i].ToString().Contains("2008"))
        {
            //array_2008[0] = aIndex;
            //array_2008[1] = arrayList1[i]; uncomment this if you wanat to add List<T> other wise comment out bottom code 
            //and uncomment code above
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
