    private List<int> _list;
    public void Process() {
        try {
            Thread.MemoryBarrier(); // Release + acquire. We only need the acquire.
            _list.Add(42);
        } finally {
            Thread.MemoryBarrier(); // Release + acquire. We only need the release.
        }
    }
