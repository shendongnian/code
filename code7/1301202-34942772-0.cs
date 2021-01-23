    // VORLAGE class containing the shared base code
    public abstract partial class VORLAGE : Window, IWindow, IDisposable
    {
        // Shared base code
    }
    
    // Your multiple window classes which utilize the same base code
    public partial class MyVorlageWindowA : VORLAGE
    {
        // Specific concrete code
    }
    
    public partial class MyVorlageWindowB : VORLAGE
    {
        // Different, specific concrete code
    }
