    List<string> votingcodes = new List<string> { "M1", "M2", "M3", "M4", "M5", "M6", "M7", "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15", "M16", "M17", "M18", "M19", "M20" };
    
    foreach (var votingcode in votingcodes)
    {
         Regex r = new Regex($@"(?<!\w){Regex.Escape(votingcode)}(?!\w)");
         DataView dv = (from t in dtFilter.AsEnumerable()
                       where r.IsMatch(t.Field<string>("FMSG_IN") ??"") select t).AsDataView();
    
    }
