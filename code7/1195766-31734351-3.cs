    new public void ClipboardCut()
    {
        base.ClipboardCut();
    
        Dispatcher.BeginInvoke(() =>
        {
            _clipboardHtml = C1.Silverlight.Clipboard.GetHtmlData();
        });
    }
