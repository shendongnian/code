    public Office.IRibbonUI ribbon;
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
       this.Application.WindowActivate += new Word.ApplicationEvents4_WindowActivateEventHandler(DocumentActivate);
    }
    private void DocumentActivate(Word.Document doc, Word.Window win)
    {
       ribbon.Invalidate();
    }
