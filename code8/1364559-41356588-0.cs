    Document extendedDocument = Globals.Factory.GetVstoObject(Application.ActiveDocument);
    int nIdx=0;
    foreach(Word.ContentControl ctrl in Application.ActiveDocument.ContentControls)
    {
    ContentControl newCC = 
    extendedDocument.Controls.AddContentControl(ctrl, "contentControlName"+nIdx.ToString());
        newCC.Entering += new ContentControlEnteringEventHandler( enteringEventHanlder);
        nIdx++;
    }
