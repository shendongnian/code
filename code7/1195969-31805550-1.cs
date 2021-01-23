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
