    public delegate void HaveDataDelegate(IList<string> data);
    public event HaveDataDelegate HaveData;
    // When there is data:
    var copy = HaveData; // Use copy to avoid race conditions
    if (copy != null) {
      copy(data);
    }
