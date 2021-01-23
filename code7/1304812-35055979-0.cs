    public virtual actionresult value(string value)
    {
        var list = value.Split('#');
        if (list != null )
        {
            List<YourClassName> arr = new List<YourClassName>();
            for (int i = 0; i < list.Length; i++)
            {
                foreach (var key in list)
                {
                    YourClassName s = new YourClassName();
                    if (key == null || string.IsNullOrEmpty(key.Trim()))
                        continue;
                    s.NRIC = key.Split('|')[0];
                    s.DOB = Convert.ToDateTime(key.Split('|')[1];);
    
                    arr.Add(s);
                }
            }
        }
    }
