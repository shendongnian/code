    public static void CallMethodUsingInvoke(Control control, Action methodOnControl)
        {
            if (control == null)
                return;
            var dlg = new MethodInvoker(methodOnControl);
            control.Invoke(dlg, control, methodOnControl);
        }
