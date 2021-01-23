    namespace configurator
    {
        class WizardWindow : IWin32Window
        {
            public WizardWindow(IntPtr handle)
            {
                Handle = handle;
            }
    
            public WizardWindow(int handle) : this(new IntPtr(handle))
            {
            }
    
            public IntPtr Handle { get; private set; }
        }
    
        public static class MainClass
        {
            private static ConfiguratorForm _configuratorForm;
    
            [DllExport("EmbedConfiguratorForm", CallingConvention.StdCall)]
            public static IntPtr EmbedConfiguratorForm(int parentWnd)
            {
                _configuratorForm = new ConfiguratorForm();
                _configuratorForm.Show(new WizardWindow(parentWnd));
                return _configuratorForm.Handle;
    
            }
    
            [DllExport("CloseConfiguratorForm", CallingConvention.StdCall)]
            public static void CloseConfiguratorForm()
            {
                if (_configuratorForm != null)
                {
                    _configuratorForm.Close();
                    _configuratorForm.Dispose();
                    _configuratorForm = null;
                }
            }
        }
    }
