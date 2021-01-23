    protected override void DisposeControls()
    {
        if (_container == null) return;
        try {
            _container.UnRegisterForDirtyRange(_cookie);
        }
        catch (System.Runtime.InteropServices.COMException ex) {
            if (ex.ErrorCode != unchecked((int)0x80004005)) throw;
            // Log mishap...
        }
        finally {
            Marshal.ReleaseComObject(_container);
            _container = null;
            _cookie = 0;
            WebBrowser.LoadCompleted -= OnWebBrowserLoadCompleted;
            WebBrowser.Dispose();
        }
    }
