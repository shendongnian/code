    public delegate void OnBooleanChanged(bool state);
    public event OnBooleanChanged OnVisibilityChangedEvent;
    private bool _isVisible;
    void Start()
    {
        _isVisible = renderer.isVisible;
        OnVisibilityChangedEvent += OnVisibilityChanged;
    }
    void Update()
    {
        if((_isVisible && !renderer.isVisible) | (!_isVisible && renderer.isVisible))
        {
            _isVisible = !_isVisible;
            // example of custom function call
            OnVisibilityChanged(_isVisible); 
            // example of event call
            if(OnVisibilityChangedEvent != null) OnVisibilityChangedEvent(_isVisible); 
        }
    }
    private void OnVisibilityChanged(bool isVisible)
    {
        // ...
    }
