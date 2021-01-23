    void OnBecameVisible()
    {
        if(OnVisibilityChangedEvent != null)
            OnVisibilityChangedEvent(true);
    }
     
    void OnBecameInvisible()
    {
        if(OnVisibilityChangedEvent != null)
            OnVisibilityChangedEvent(false);
    }
