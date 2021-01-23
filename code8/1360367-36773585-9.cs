    public static class Extensions
    {
        public static void SetStyle(this Control control, ControlStyles flags, bool value)
        {
            Type type = control.GetType();
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo method = type.GetMethod("SetStyle", bindingFlags);
            if (method != null)
            {
                object[] param = { flags, value };
                method.Invoke(control, param);
            }
        }
    }
