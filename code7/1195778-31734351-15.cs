    new public void ClipboardCopy()
    {
        _clipboardImages = FindImages(Selection);
    
        base.ClipboardCopy();
        // ... as posted above
    }
