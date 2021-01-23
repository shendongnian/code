    /// <summary>
    /// Gets the URI of the current document.
    /// </summary>
    public String DocumentUri
    {
        get { return _location.Href; }
        protected set
        {
            _location.Changed -= LocationChanged;
            _location.Href = value;
            _location.Changed += LocationChanged;
        }
    }
