    public static class UIHelper
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int _fpreset();
        private static DispatcherOperationCallback _oldUpdateLayoutCallback;
        private static object UpdateLayoutCallback(object arg)
        {
            try
            {
                _oldUpdateLayoutCallback(arg);
                return null;
            }
            catch (System.Xaml.XamlParseException ex)
            {
                if (!(ex.InnerException is ArithmeticException))
                {
                    throw;
                }
            }
            // Try to update layout second time after floating point unit reset
            _fpreset();
            _oldUpdateLayoutCallback(arg);
            return null;
        }
        public static bool InitWPFArithmeticExceptionWorkaround()
        {
            try
            {
                // Call fpreset early just to handle case with missed "msvcrt.dll" 
                // in future Windows versions
                _fpreset();
                Assembly assembly = typeof(System.Windows.UIElement).Assembly;
                Type managerType = assembly.GetType("System.Windows.ContextLayoutManager");
                if (managerType != null)
                {
                    FieldInfo field = managerType.GetField("_updateCallback", BindingFlags.Static | BindingFlags.NonPublic);
                    if (field != null)
                    {
                        _oldUpdateLayoutCallback = field.GetValue(null) as DispatcherOperationCallback;
                        if (_oldUpdateLayoutCallback != null)
                        {
                            field.SetValue(null, new DispatcherOperationCallback(UpdateLayoutCallback));
                            return true;
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }
    }
