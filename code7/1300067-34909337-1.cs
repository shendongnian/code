    // define the stringBuilder
    StringBuilder text = new StringBuilder();
    // define the loop to concat all values separated by ',' comma
    for (var i = 0; i < files.Count; i++)
        text.AppendFormat("{0},", nFIleUpload.OrgFileName);
    // get the output
    string s = text.ToString();
    // remove the last comma if necessary
    if (s.EndsWith(","))
        s = s.Remove(s.Length - 1);
