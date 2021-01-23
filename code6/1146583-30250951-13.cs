    private volatile bool _executing;
    private volatile List<int> _list;
    public void Process() {
        try {
             // This is an acquire, because we're *reading* from a volatile field.
            _list.Add(42);
        } finally {
            // This is a release, because we're *writing* to a volatile field.
            _executing = false;
        }
    }
