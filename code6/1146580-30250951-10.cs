    private bool _executing;
    private List<int> _list;
    public void Process() {
        try {
            Thread.MemoryBarrier(); // Release + acquire. We only need the acquire.
            if (!_executing) {
                _list.Add(42);
            }
        } finally {
            _executing = false;
            Thread.MemoryBarrier(); // Release + acquire. We only need the release.
        }
    }
