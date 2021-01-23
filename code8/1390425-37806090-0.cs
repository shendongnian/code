     1: private void btnRecall_Click(object sender, RibbonControlEventArgs e)
        2:        {
        3:            Outlook.MailItem oldMailItem = GetMailItem(e);
        4:            Inspector inspect=  oldMailItem.GetInspector;
        5:            inspect.Display(false);
        6:            inspect.CommandBars.ExecuteMso("RecallThisMessage");           
        7:        }
        8:
        9:    private Microsoft.Office.Interop.Outlook.MailItem GetMailItem(RibbonControlEventArgs e)
        10:        {
        11:            // Check to see if a item is select in explorer or we are in inspector.
        12:            if (e.Control.Context is Microsoft.Office.Interop.Outlook.Inspector)
        13:            {
        14:                Microsoft.Office.Interop.Outlook.Inspector inspector = (Microsoft.Office.Interop.Outlook.Inspector)e.Control.Context;
        15:
        16:                if (inspector.CurrentItem is Microsoft.Office.Interop.Outlook.MailItem)
        17:                {
        18:                    return inspector.CurrentItem as Microsoft.Office.Interop.Outlook.MailItem;
        19:                }
        20:            }
        21:
        22:            if (e.Control.Context is Microsoft.Office.Interop.Outlook.Explorer)
        23:            {
        24:                Microsoft.Office.Interop.Outlook.Explorer explorer = (Microsoft.Office.Interop.Outlook.Explorer)e.Control.Context;
        25:
        26:                Microsoft.Office.Interop.Outlook.Selection selectedItems = explorer.Selection;
        27:                if (selectedItems.Count != 1)
        28:                {
        29:                    return null;
        30:                }
        31:
        32:                if (selectedItems[1] is Microsoft.Office.Interop.Outlook.MailItem)
        33:                {
        34:                    return selectedItems[1] as Microsoft.Office.Interop.Outlook.MailItem;
        35:                }
        36:            }
        37:
        38:            return null;
        39:        }
