        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string lpszParentClass = "IEFrame";
            IntPtr ParenthWnd = new IntPtr(0);
            ParenthWnd = FindWindow(lpszParentClass, null);
            if (!ParenthWnd.Equals(IntPtr.Zero))
            {
                var parent = AutomationElement.FromHandle(ParenthWnd);
                Automation.AddAutomationPropertyChangedEventHandler(parent, TreeScope.Element, WindowMoved, AutomationElement.BoundingRectangleProperty);
            }
        }
        private void WindowMoved(object sender, AutomationPropertyChangedEventArgs e)
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (e.NewValue != null)
                {
                    var newPosition = (Rect)e.NewValue;
                    this.Left = newPosition.Left;
                    this.Top = newPosition.Top;
                }
            }));
        }
