    new public void ClipboardCopy()
    {
        base.ClipboardCopy();
    
        Dispatcher.BeginInvoke(() =>
        {
            _clipboardHtml = C1.Silverlight.Clipboard.GetHtmlData();
        });
    }
