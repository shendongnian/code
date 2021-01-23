    [Guid("414C3CDC-856B-4F5B-8538-3131C6302550"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUIAutomationGridPattern
    {
        UIAutomationClient.IUIAutomationElement GetItem(int row, int column);
        ...
    }
    
