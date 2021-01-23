    private bool _shouldSerializeUserId;
    // You can this method to set value.
    public void SetShouldSerializeUserId(bool shouldSerializeUserId)
    {
       _shouldSerializeUserId = shouldSerialize;
    }
    public bool ShouldSerializeUserId()
    {
       return _shouldSerializeUserId;
    }
