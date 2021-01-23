    public abstract class BaseWindow : Window {
        protected static bool IsValidDate(string date) {
            // Do your stuff...
        }
    }
    // This is your actual WPF page class - when Visual Studio builds it, just change the 
    // inheritance from "Window" to "BaseWindow"
    public partial class MyWindow : BaseWindow {
    }
