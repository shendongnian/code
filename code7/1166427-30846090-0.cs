    private Office.IRibbonUI ribbon;
    public void Ribbon_Load(Office.IRibbonUI ribbonUI)
    {
    Globals.ThisAddIn.Application.DocumentChange += DocumentChangeEvent;
    }
    
    private void DocumentChangeEvent()
    {
    ribbon.Invalidate();
    }
