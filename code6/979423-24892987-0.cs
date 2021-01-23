    Clipboard.SetDataObject(wb);
    DataObject dataObj=new DataObject();
    
    foreach(string format in Clipboard.GetDataObject().GetFormats())
    {
        // have a look of its current available Formats, and add anything you feel is necessary.
        if(format.Contains("Biff")||format==DataFormats.Text)
        {
            dataObj.SetData(format, Clipboard.GetDataObject().GetData(format));
        }
    }
    
    Clipboard.SetDataObject(dataObj);
