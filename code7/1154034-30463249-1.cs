    private bool _isVisible;
    void Start()
    {
        _isVisible = renderer.isVisible;
    }
    void Update()
    {
        if((_isVisible && !renderer.isVisible) | (!_isVisible && renderer.isVisible))
        {
            _isVisible = !_isVisible;
            OnVisibilityChanged(_isVisible);
        }
    }
