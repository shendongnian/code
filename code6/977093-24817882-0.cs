    using Microsoft.Office.Interop.Outlook;
    //C:\Program Files\Microsoft Visual Studio 11.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Outlook.dll
    //14.0.0.0 or 12.0.0.0 - it works from Outlook 2007 and higher
    namespace ConsoleApplication1
    {
        class Program
        {
            public void SendMail()
            {
                //// Create the Outlook application by using inline initialization.
                Application oApp = new Application();
                ////Create the new message by using the simplest approach.
                MailItem oMsg = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
                oMsg.SendUsingAccount = oApp.Session.Accounts[0];
