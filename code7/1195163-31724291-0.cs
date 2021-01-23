    [ComVisible(true)]
        public class ScriptManager
        {
            // Variable to store the form of type Form1.
            private Window _window;
    
            // Constructor.
            public ScriptManager(Window window)
            {
                // Save the form so it can be referenced later.
                _window = window;
            }
    
            // This method can be called from JavaScript.
            public void MethodToCallFromScript()
            {
                // Call a method on the form.
                _window.Close();
            }
        }
