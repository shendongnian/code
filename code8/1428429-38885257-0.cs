    var mi;
    var inspector = MyAddIn.Application.ActiveInspector();
    if (inspector != null)
    {
       // get existing
       mi = inspector.CurrentItem as MailItem;
    }
    else 
    {
       // otherwise, create new one
       mi = MyAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
     }
    // now use it to attach file   
    if (mi != null)
    {
       mi.Attachments.Add(myFilePath);
    } 
