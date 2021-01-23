    // Create the Outlook application by using inline initialization.
    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
    Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
    Microsoft.Office.Interop.Outlook.Inspector oInspector = oMsg.GetInspector;
        
    Microsoft.Office.Interop.Outlook.Recipient oTORecipt = oMsg.Recipients.Add(email);
    oTORecipt.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olTo;
    oTORecipt.Resolve();
 
    oMsg.Subject = "Happy Birthday";
    oMsg.HTMLBody = body; //copy the HTML msg body taken from the HTML file. Body is a string
    string date = DateTime.Today.ToString("MM-dd-yyyy");
    oMsg.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
    oMsg.Save();
    oMsg.Display();
     //Explicitly release objects.
     oMsg = null;
     oApp = null; //This has to be done at the end
