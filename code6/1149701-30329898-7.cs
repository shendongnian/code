    public class IronPythonControl : ContentControl 
    {
        public IronPythonControl(string name)
        {
            Debug.Assert(!string.IsNullOrEmpty(name), "No name provided for control");
            Content = LoadControl(name);
        }
        public FrameworkElement LoadControl(string name){/*Load XAML Control from database here*/}
    }
