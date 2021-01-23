    bool XLAppBusy()
    {
        if (Globals.ThisAddIn.Application.Interactive == false)
        {
            return false;
        }
    
        try
        {
            Globals.ThisAddIn.Application.Interactive = false;
            Globals.ThisAddIn.Application.Interactive = true;
        }
        catch
        {
            return true;
        }
            return false;
    }
    
    private void buttonFoo_Click(object sender, RibbonControlEventArgs e)
    {
        if (XLAppBusy() == false)
        {       
            ws.Range["A1"].Value = "bar";
        }
    } 
