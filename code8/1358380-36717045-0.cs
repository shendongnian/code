    public static List<string> GetWorkPackages(string prefixText, DropDownList ddl)
    {
        DataTable dt = getWorkpackages(ddl.SelectedValue);
        List<string> wps = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            wps.Add(dt.Rows[i][1].ToString());
        }
        return wps;
    }
