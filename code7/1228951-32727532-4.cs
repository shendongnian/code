    public class KeyPressesWithArgsBehavior : Behavior<UIElement>
    {
        #region KeyDown Press DependencyProperty
        public ICommand KeyDownCommand
        {
            get { return (ICommand) GetValue(KeyDownCommandProperty); }
            set { SetValue(KeyDownCommandProperty, value); }
        }
        public static readonly DependencyProperty KeyDownCommandProperty =
            DependencyProperty.Register("KeyDownCommand", typeof (ICommand), typeof (KeyPressesWithArgsBehavior));
        #endregion KeyDown Press DependencyProperty
        #region KeyUp Press DependencyProperty
        public ICommand KeyUpCommand
        {
            get { return (ICommand) GetValue(KeyUpCommandProperty); }
            set { SetValue(KeyUpCommandProperty, value);}
        }
        public static readonly DependencyProperty KeyUpCommandProperty = 
            DependencyProperty.Register("KeyUpCommand", typeof(ICommand), typeof (KeyPressesWithArgsBehavior));
        #endregion KeyUp Press DependencyProperty
        protected override void OnAttached()
        {
            AssociatedObject.KeyDown += new KeyEventHandler(AssociatedUIElementKeyDown);
            AssociatedObject.KeyUp += new KeyEventHandler(AssociatedUIElementKeyUp);
            base.OnAttached();
        }
        protected override void OnDetaching()
        {
            AssociatedObject.KeyDown -= new KeyEventHandler(AssociatedUIElementKeyDown);
            AssociatedObject.KeyUp -= new KeyEventHandler(AssociatedUIElementKeyUp);
            base.OnDetaching();
        }
        private void AssociatedUIElementKeyDown(object sender, KeyEventArgs e)
        {
            if (KeyDownCommand != null)
            {
                ObjectAndArgs oa = new ObjectAndArgs {Args = e, Object = AssociatedObject};
                KeyDownCommand.Execute(oa);
            }
        }
        private void AssociatedUIElementKeyUp(object sender, KeyEventArgs e)
        {
            if (KeyUpCommand != null)
            {
                KeyUpCommand.Execute(AssociatedObject);
            }
        }
    }
