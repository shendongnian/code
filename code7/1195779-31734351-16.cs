    new public void ClipboardCut()
    {
        _clipboardImages = FindImages(Selection);
    
        base.ClipboardCut();
        // ... as posted above
    }
