    var parameters = new NameValueCollection
    {
        { "parent_id", "1111" },
        { "tracker", "MyTrackerName" },
    }
    var rmMan = new RedmineManager(RedmineHost, RedmineKey);
    var issues = rmMan.GetObjectList<Issue>(parameters);
