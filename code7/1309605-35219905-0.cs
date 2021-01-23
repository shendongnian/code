    static Dictionary<string, Tuple<DateTime, QueryCompilation>> _cache
        = new Dictionary<string, System.Tuple<System.DateTime, QueryCompilation>>();
    
    public static QueryCompilation GetCompilation (string scriptFilePath)
    {
        Tuple<DateTime, LINQPad.ObjectModel.QueryCompilation> entry;
        var writeTime = new FileInfo (scriptFilePath).LastWriteTimeUtc;
    
        lock (_cache)
            if (_cache.TryGetValue (scriptFilePath, out entry) && entry.Item1 == writeTime)
                return entry.Item2;
    
        var compiledScript = LINQPad.Util.Compile (scriptFilePath, true);
    
        lock (_cache)
            _cache [scriptFilePath] = Tuple.Create (writeTime, compiledScript);
    
        return compiledScript;
    }
