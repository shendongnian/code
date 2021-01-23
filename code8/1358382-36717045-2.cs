    public static List<string> GetWorkPackages(string prefixText, string ddlVal)
    {
        DataTable dt = getWorkpackages(ddlVal);
        List<string> wps = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            wps.Add(dt.Rows[i][1].ToString());
        }
        return wps;
    }
