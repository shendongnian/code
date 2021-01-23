    public Light HighlightPrefab;
    ...
    void Start()
    {
        Reward2 obj = gameObject.AddComponent<Reward2>();
        obj.Highlight = HighlightPrefab;
    }
