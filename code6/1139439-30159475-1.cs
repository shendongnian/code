    void CreatePdfViewerAndOpenFile(string pdfFile)
    {
        short AV_DOC_VIEW = 2;
        short PDUseBookmarks = 3;
        short AVZoomFitWidth = 2;
        Type AcroExch_AVDoc = Type.GetTypeFromProgID("AcroExch.AVDoc");
        _acroExchAVDoc = (Acrobat.CAcroAVDoc)Activator.CreateInstance(AcroExch_AVDoc);
        bool ok = _acroExchAVDoc.OpenInWindowEx(pdfFile, this.Handle.ToInt32(), AV_DOC_VIEW, -1, 0, PDUseBookmarks, AVZoomFitWidth, 0, 0, 0);
            
        if (ok)
        {
            CAcroPDDoc pdDoc = (CAcroPDDoc)_acroExchAVDoc.GetPDDoc();
            object jsObj = pdDoc.GetJSObject();
            Type jsObjType = jsObj.GetType();
            object collab = jsObjType.InvokeMember("collab",
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance,
                null, jsObj, null);
                
            jsObjType.InvokeMember("showAnnotToolsWhenNoCollab",
                BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance,
                null, collab, new object[] { true });
        }
    }
