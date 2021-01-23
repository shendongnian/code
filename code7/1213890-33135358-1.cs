    public class CustomDataGrid : DataGrid
    {
        //Override automation peer that the base class provides as it doesn't expose automation peers for the row details
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new GenericAutomationPeer(this);
        }
    }
