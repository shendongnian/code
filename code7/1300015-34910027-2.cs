    public static class ControlUtils
    {
        static readonly Action<Control, bool> CreateControlFunc = (Action<Control, bool>)Delegate.CreateDelegate(typeof(Action<Control, bool>),
            typeof(Control).GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(bool) }, null));
        public static void CreateControls(this Control target)
        {
            if (!target.Created)
                CreateControlFunc(target, true);
            else
                for (int i = 0; i < target.Controls.Count; i++)
                    target.Controls[i].CreateControls();
        }
    }
