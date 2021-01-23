    //First, declare the interface type of Explorer
    public static Outlook.Explorer currentExplorer;
    
    //Create a method to identify the Inline response as a MailItem
        private void ThisAddIn_InlineResponse(object Item)
        {
            if (Item != null)
            {
                Outlook.MailItem mailItem = Item as Outlook.MailItem;
            }
        }
    
    //Direct to the ThisAddIn_Startup() method and add an event handler for the Inline Response Method
    currentExplorer.InLineResponse += ThisAddIn_InLineResponse;
    
    //Access the popped in reply and forward window where required
    object item = null;
    item = currentExplorer.ActiveInlineResponse;
    
