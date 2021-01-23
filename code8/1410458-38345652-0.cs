    public interface IWindowFactory
    {
        Window CreatePrintWindow();
    }
    
    public void YourMethod(IWindowFactory windowFactory)
    {
        // ...
        var window = windowFactory.CreatePrintWindow();
        // ...
    }
