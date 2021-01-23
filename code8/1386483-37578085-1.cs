    Outlook.MailItem mailItem = item as Outlook.MailItem;
    Outlook.Inspector inspector = mailItem.GetInspector;
    Word.Document document = (Microsoft.Office.Interop.Word.Document)inspector.WordEditor;
    Word.Application app = document.Application;
    app.WindowSelectionChange += new Microsoft.Office.Interop.Word.ApplicationEvents4_WindowSelectionChangeEventHandler(YOUR_METHOD_HERE);
