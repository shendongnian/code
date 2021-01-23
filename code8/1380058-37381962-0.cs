        public static void InvokeSafely(this Control control, Action<Control> action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((Action)(() => action?.Invoke(control)));
            }
            else
            {
                action?.Invoke(control);
            }
        }
