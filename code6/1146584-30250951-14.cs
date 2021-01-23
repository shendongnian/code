    private List<int> _list;
    // This is somehow magically launched when the other thread is not executing.
    public void Process() {
        try {
            Thread.MemoryBarrier(); // Release + acquire. We only need the acquire.
            _list.Add(42);
        } finally {
            Thread.MemoryBarrier(); // Release + acquire. We only need the release.
        }
    }
