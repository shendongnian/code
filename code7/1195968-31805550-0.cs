var query = ParseObject.GetQuery(ParseObjectsName.PlayerProfile.ToString()).WhereEqualTo(PlayerProfileDataVariableName.ID.ToString(),ID);
        query.FindAsync().ContinueWith(t =>
                                       {
            IEnumerable<ParseObject> results = t.Result;
            List<ParseObject>  totalResultsForQuery = new List<ParseObject>();
            foreach(ParseObject obj in results)
            {
                totalResultsForQuery.Add(obj);
            }
}
In your case make sure you are setting the correct name for table name and variable name. 
Secondly, may be your internet was not working at that point of time. you should also check t.isFaulted or t.isCancelled before trying to check the result.
