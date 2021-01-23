    new public void ClipboardPaste()
    {
        // If the text in the global clipboard matches the text stored in _clipboardText it is 
        // assumed that the HTML in the C1 clipboard is still valid 
        // (no other Copy was made by the user).
        string current = C1.Silverlight.Clipboard.GetHtmlData();
    
        if(current == _clipboardHtml)
        {
            // text is the same -> Let base class paste HTML
            base.ClipboardPaste();
        }
        else
        {
            // let base class paste text only
            string text = C1.Silverlight.Clipboard.GetTextData();
            C1.Silverlight.Clipboard.SetData(text);
    
            base.ClipboardPaste(); 
    
            Dispatcher.BeginInvoke(() =>
            {
                // restore clipboard
                C1.Silverlight.Clipboard.SetData(current);
            });
        }
    }
