    public static string NewsListTitle(int count, int categoryId, string domainName)
    {
        StringBuilder cnt = new StringBuilder();
        foreach(IDataRecord rc in DbHelper.Reader("......", ....);
        {
             cnt.Append(@"<li><a target=\"_blank\" href=\"http://" + domainName + "/news/" +
                   rc.GetInt32(rc.GetOrdinal("NewsID")).ToString() + "\"\">" + 
                   rc.GetString(rc.GetOrdinal("Title")) + "</a></li>");
        }
    }
    return cnt.ToString();
