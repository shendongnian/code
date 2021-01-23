    public class SecondWindowLoadingBehavior:Behavior<FrameworkElement>
    {
        private Window _window;
        public static readonly DependencyProperty CanProvideDataForSecondWindowProperty = DependencyProperty.Register(
            "CanProvideDataForSecondWindow", typeof (ICanProvideDataForSecondWindow), typeof (SecondWindowLoadingBehavior), new PropertyMetadata(default(ICanProvideDataForSecondWindow)));
        /// <summary>
        /// helps to control dialog between first and second window
        /// </summary>
        public ICanProvideDataForSecondWindow CanProvideDataForSecondWindow
        {
            get { return (ICanProvideDataForSecondWindow) GetValue(CanProvideDataForSecondWindowProperty); }
            set { SetValue(CanProvideDataForSecondWindowProperty, value); }
        }
        public static readonly DependencyProperty IsSecondWindowShouldBeShownProperty = DependencyProperty.Register(
            "IsSecondWindowShouldBeShown", typeof (bool), typeof (SecondWindowLoadingBehavior), new PropertyMetadata(default(bool), IsSecondWindowShouldBeShownPropertyChangedCallback));
        //when the IsSecondWindowShouldBeShown dependency property will be changed, will trigger the window showing
        private static void IsSecondWindowShouldBeShownPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var isShouldBeShown = (bool) args.NewValue;
            var behavior = dependencyObject as SecondWindowLoadingBehavior;
            if (isShouldBeShown == false || behavior == null || behavior.CanProvideDataForSecondWindow == null)
            {
                return;
            }
            behavior.ShowSecondWindow();
        }
        /// <summary>
        /// helps to control the second window loading
        /// </summary>
        public bool IsSecondWindowShouldBeShown
        {
            get { return (bool)GetValue(IsSecondWindowShouldBeShownProperty); }
            set { SetValue(IsSecondWindowShouldBeShownProperty, value); }
        }
        //helps to prepare and show the second window
        private void ShowSecondWindow()
        {
            _window = new SecondWindow {DataContext = new SecondWindowDataContext(CanProvideDataForSecondWindow)};
            _window.Closing += WindowOnClosing;
            _window.Show();
        }
        //disposes a data context instance when a window was closed
        private void WindowOnClosing(object sender, CancelEventArgs e)
        {
            _window.Closing -= WindowOnClosing;
            IsSecondWindowShouldBeShown = false;
            var disposableDataContext = _window.DataContext as IDisposable;
            if (disposableDataContext == null) return;
            disposableDataContext.Dispose();
        }
    }
