<!-- -->
    // common extension methods
    public static class MyControlHelper
    {
        public static void MakeInvisible<TControl>(this TControl control) where TControl : Control, IExtended
        {
            control.Extra.MakeInvisible();
        }
        public static void Rename<TControl>(this TControl control) where TControl : Control, IExtended
        {
            control.Text = control.Extra.Property1;
        }
    }
