    Microsoft.Office.Interop.Word._Application oWord; 
    try
    {
        oWord = Marshal.GetActiveObject("Word.Application") as
            Microsoft.Office.Interop.Word.Application;
    }
    catch (COMException ce)
    {
        // oWord still not initialized ....
        if (ce.ErrorCode == unchecked((int)0x800401E3))
            oWord = new Microsoft.Office.Interop.Word.Application();
        else
            ; // .... and still not initialized ....
    }
    oWord.ScreenUpdating = false;
