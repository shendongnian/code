    private static object _sync = new object();
    public List<UserSecure> GetByKey(short Group)
    {
        lock(_sync)
        {
            var listView = new List<UserSecure>();
            if (_Users != null)
            {
                var getList = _Users.TryGetValue(Group, out listView);
            }
            return listView;
        }
    }
