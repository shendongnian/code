    protected override void WndProc(ref Message m)
    {
        ...
        if (m.Msg == WM_DRAWCLIPBOARD)
        {
            IDataObject iData = Clipboard.GetDataObject();
            ClipBoard.SetDataObject(iData);
        }
    }
