    [Export(typeof(ITestExplorer))]
    [Export(typeof(ICoreDataProvider))]
    public class TestExplorerViewModel : Tool, ITestExplorer, IDataErrorInfo, IDisposable
    {
        // Implementation.
    }
    
    [Export(typeof(ITicker))]
    [Export(typeof(ICoreDataProvider))]
    public class TickerViewModel : Tool, ITicker, IDataErrorInfo
    {
        // Implementation.
    }
