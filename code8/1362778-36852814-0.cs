    public class UIObserveTitleChangedViewController : UIViewController
    {
        public event TitleChangedEvent TitleChanged;
        public override string Title
        {
            get
            {
                return base.Title;
            }
            set
            {
                var oldTitle = base.Title;
                if (oldTitle == value)
                    return;
                base.Title = value;
                OnTitleChanged(new TitleChangedEventArgs(value, oldTitle));
            }
        }
        protected virtual void OnTitleChanged(TitleChangedEventArgs args)
        {
            TitleChanged?.Invoke(this, args);
        }
        #region ctor
        public UIObserveTitleChangedViewController() { }
        public UIObserveTitleChangedViewController(NSCoder coder) : base(coder) { }
        protected UIObserveTitleChangedViewController(NSObjectFlag t) : base(t) { }
        protected internal UIObserveTitleChangedViewController(IntPtr handle) : base(handle) { }
        public UIObserveTitleChangedViewController(string nibName, NSBundle bundle) : base(nibName, bundle) { }
        #endregion
    }
