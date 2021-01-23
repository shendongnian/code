        public static IntPtr MessageReader(IntPtr hwnd, int message, IntPtr lParam, IntPtr wParam, ref bool result)
        {
            _log.Error(string.Format("MessageReader - {0}, {1}, {2}, {3}", hwnd, message, lParam, wParam));
            return IntPtr.Zero;
        }
        public static IntPtr MessageReader(IntPtr hwnd, int message, IntPtr lParam, IntPtr wParam, ref bool result)
        ....
            FieldInfo ArgsField = typeof(DispatcherOperation).GetField("_args", BindingFlags.NonPublic | BindingFlags.Instance);
            Dispatcher.CurrentDispatcher.Hooks.OperationStarted += new DispatcherHookEventHandler((obj, args) =>
            {
                System.Windows.Interop.HwndSource source = ArgsField.GetValue(args.Operation) as System.Windows.Interop.HwndSource;
                if (source != null)
                {
                    source.AddHook(new System.Windows.Interop.HwndSourceHook(MessageReader));
                }
            });
            Dispatcher.Run();
