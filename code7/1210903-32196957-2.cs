    public static string Get_AreaID_Auto()
    {
        string result = "";
        if (db.TESTs.ToList().Count <= 0)
        {
            result = "01";
        }
        else
        {
	var items = db.TESTs.OrderBy(e => e.CAT_ID).ToArray();
	for(int i=0;i<items.count;i++)
	{	
		if ((i==items.count-1) || (int.Parse(items[i].CAT_ID.Substring(1)) + 1 != int.Parse(items[i+1].CAT_ID.Substring(1))))
                {
                    result = int.Parse(items[i].CAT_ID.Substring(1) + 1);
                    break;
                }	
	}    
        }
        return string.Format("C{0:D2}",result);
    }
