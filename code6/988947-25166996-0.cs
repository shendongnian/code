    //... user instance fields ...
    private static Dictionary<int, User> cache = new Dictionary<int, User>();
    private static object lockObj = new object();
    public static User LoadByID(int id)
    {
        lock (lockObj) //Prevent double-adding items
        {
            if (cache.ContainsKey(id))
            {
                return cache[id]; //We've already loaded the record.
            }
            else
            {
                //Some function that actually calls the database
                //and constructs user objects
                User loaded = LoadUserInternal(id);
                cache.Add(id, loaded)
                return loaded;
            }
        }
    }
    private static User LoadUserInternal(int id)
    {
        //Load and construct the user
    }
