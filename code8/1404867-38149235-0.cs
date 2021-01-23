    const int WM_CLIPBOARDUPDATE = 0x31D;
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_CLIPBOARDUPDATE:
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string data = (string)iData.GetData(DataFormats.Text);
                }
                break;
    
    
            default:
                base.WndProc(ref m);
                break;
        }
    }
    
    
