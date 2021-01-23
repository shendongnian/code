    ///
    /// for locking synhronize
    ///
    private static readonly object syncLock = new object();
    /// <summary>
    /// Dictionary of all languages
    /// </summary>
    private static Dictionary<int, Language> GetLanguagesDictionary()
    {
        const string cacheIndex = Settings.CachePrefix + "LanguagesDictionary";
        var context = HttpContext.Current;
        if (context.Cache[cacheIndex] == null)
        {
            lock (syncLock)
            {
                if (context.Cache[cacheIndex] == null)
                {
                    var dict = new Dictionary<int, Language>();
                    using (var db = new DBContext())
                    {
                        var q = db.Languages;
                        foreach (var rec in q)
                        {
                            dict.Add(rec.ID, new Language(rec));
                        }
                    }
                    context.Cache.Add(cacheIndex, dict, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                }
            }
        }
        return (Dictionary<int, Language>)context.Cache[cacheIndex];
    }
