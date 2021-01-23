    Microsoft.Office.Interop.Word._Application oWord; 
    try
    {
        oWord = Marshal.GetActiveObject("Word.Application") as
            Microsoft.Office.Interop.Word.Application;
    }
    catch (COMException ce)
    {
        if (ce.ErrorCode == unchecked((int)0x800401E3))
            oWord = new Microsoft.Office.Interop.Word.Application();
    }
    oWord.ScreenUpdating = false;
