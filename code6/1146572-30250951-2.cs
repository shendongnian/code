    private bool _executing;
    private List<int> _list;
    public void Process() {
        try {
            Thread.MemoryBarrier(); // Acquire
            _list.Add(42);
        } finally {
            _executing = false;
            Thread.MemoryBarrier(); // Release
        }
    }
