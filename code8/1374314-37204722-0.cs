    private void DocumentOpened(object sender)
    {
        Word._Document document = Globals.ThisAddIn.Application.ActiveDocument;
        Office.DocumentProperties properties = document.BuiltInDocumentProperties;
        if((properties["Author"].Value as string).Equals("MyMenuTool"))
        {
            //Show or activate the menu
        }
    }
