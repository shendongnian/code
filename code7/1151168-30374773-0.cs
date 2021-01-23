    public void TestFieldsUpdate(Office.IRibbonControl control, bool cancelDefault)
    {
        MessageBox.Show("Field Updated");
        Globals.ThisAddIn.Application.Selection.Fields.Update();
     }
