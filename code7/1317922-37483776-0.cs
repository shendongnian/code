    namespace CaptainPav.Testing.UI.CodedUI.PageModeling.Win
    {
        public class IESecurityWindow<T> : PageModelBase<WinWindow>
         {
            protected const string SecurityWindowName = "Internet Explorer Security";
            internal protected override WinWindow Me => new WinWindow().Extend(WinWindow.PropertyNames.Name, SecurityWindowName, PropertyExpressionOperator.EqualTo);
            protected WinButton AllowButton => this.Me.Find<WinButton>(WinButton.PropertyNames.Name, "Allow", PropertyExpressionOperator.EqualTo);
	        internal readonly T AllowModel;
            public IESecurityWindow(T allowModel)
            {
                this.AllowModel = allowModel;
            }
            public T ClickAllow()
            {
                // if not IE, this will return false and the next model is returned; change the time if you need more or less wait
                if (this.AllowButton.IsActionable(3000))
                {
                    Mouse.Click(this.AllowButton);
                }
                return AllowModel;
            }
        }
    }
