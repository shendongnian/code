    public bool IsVisible
    {
        get 
        {
            return gameObject.renderer.isVisible;
        }
        set
        {
            if(value != gameObject.renderer.isVisible)
            {
                OnVisibilityChanged(); // or OnVisibilityChanged(value);
                gameObject.renderer.isVisible = value;
            }
        }
    }
