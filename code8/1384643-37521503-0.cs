    static List<Foo> fetched;
    static readonly object syncLock = new object(); // because: threading
    public static List<Foo> Whatever {
        get {
            var tmp = fetched;
            if(tmp != null) return tmp;
            lock(syncLock) {
                tmp = fetched;
                if(tmp != null) return tmp; // double-checked lock
                return fetched = GetTheActualData();
            }
        }
    }
    private static List<Foo> GetTheActualData() {...}
