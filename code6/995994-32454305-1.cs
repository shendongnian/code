    List<string> lCodes = new List<string>();
    foreach (string code in item.Codes)
    {
        lCodes.Add(String.Format("('{0}','{1}')", UID, MySqlHelper.EscapeString(code)));
    }
    string cCommand = "INSERT INTO Code (UserID, Code) VALUES " + string.Join(",", lCodes);
    using (MySqlCommand myCmdNested = new MySqlCommand(cCommand, mConnection))
    {
        myCmdNested.ExecuteNonQuery();
    }
