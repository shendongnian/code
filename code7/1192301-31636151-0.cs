    public List<Event> FilteredNames
    {
        get
        {
            return (from name in SearchEventCollection where name.EventName.StartsWith(filter) select name).ToList();
        }
    }
