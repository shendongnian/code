    Dictionary<string, object> d = new Dictionary<string, object>();
    
    private void button1_Click(object sender, EventArgs e)
    {
        d = new Dictionary<string, object>();
        IDataObject o = Clipboard.GetDataObject();
        foreach (string format in o.GetFormats())
        {
            d.Add(format, o.GetData(format));
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        DataObject o = new DataObject();
    
        foreach (string format in d.Keys)
        {
            o.SetData(format, d[format]);
        }
    
        Clipboard.SetDataObject(o);
    
    }
