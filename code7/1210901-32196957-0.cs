    public static string Get_AreaID_Auto()
    {
        string result = "";
        if (db.TESTs.ToList().Count <= 0)
        {
            result = "01";
        }
        else
        {
		var item = db.TESTs.OrderByDescending(e => e.CAT_ID).First();
		result = int.Parse(item.CAT_ID.Substring(1)) + 1;    
        }
        return string.Format("C{0:D3}",result);
    }
