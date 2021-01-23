    private volatile bool _executing;
    private List<int> _list;
    public void Process() {
        try {
             // This is an acquire, because we're *reading* from a volatile field.
            if (!_executing) {
                _list.Add(42);
            }
        } finally {
            // This is a release, because we're *writing* to a volatile field.
            _executing = false;
        }
    }
