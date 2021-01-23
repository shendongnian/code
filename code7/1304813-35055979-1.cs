    public virtual ActionResult value(string value)
    {
        List<YourClassName> arr = new List<YourClassName>();
        if(string.IsNullOrEmpty(value)
           return View(arr);
        var list = value.Split('#');
        // Not needed 
        // if (list != null )
        // {
        //    for (int i = 0; i < list.Length; i++)
        //    {
                foreach (var key in list)
                {
                    // In every loop create a new instance of s of the 
                    // exact type for your class 
                    YourClassName s = new YourClassName();
                    if (string.IsNullOrWhiteSpace(key))
                        continue;
                    s.NRIC = key.Split('|')[0];
                    s.DOB = Convert.ToDateTime(key.Split('|')[1];);
    
                    arr.Add(s);
                }
        //    }
        // }
        return View(arr);
    }
