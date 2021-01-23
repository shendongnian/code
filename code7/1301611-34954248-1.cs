    protected override void WndProc(ref Message m)
    {
        ...
        if (m.Msg == WM_DRAWCLIPBOARD)
        {
            IDataObject iData = Clipboard.GetDataObject();
            ClipBoard.SetDataObject(iData);
        }
        if (m.Msg == WM_RENDERFORMAT)
            Console.WriteLine("Clipboard data requested");
    }
