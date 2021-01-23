    [ComVisible(true)]
    public class OutlookAddInExtensibility : IRibbonExtensibility
    {
        public string GetCustomUI(string RibbonID)
        {
            return
    @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <customUI xmlns=""http://schemas.microsoft.com/office/2009/07/customui"">
        <contextMenus>    
            <contextMenu idMso=""ContextMenuMailItem"">
                <button 
                    id=""MyContextMenuMailItem""
                    label=""ContextMenuMailItem""
                    onAction=""RibbonMenuClick""
                    />
            </contextMenu>  
        </contextMenus>
    </customUI>
    ";
        }
        public void RibbonMenuClick(IRibbonControl control)
        {
            System.Diagnostics.Trace.WriteLine($"RibbonMenuClick control: {control} type {control?.GetType().Name ?? "(null)"}");
        }
    }
