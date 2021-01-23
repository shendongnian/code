    using Microsoft.Office.Interop.Outlook;
    ...
    Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
    Microsoft.Office.Interop.Outlook.MailItem msg = app.CreateItem(0);
    msg.Subject = "test";
    msg.Display(false):
