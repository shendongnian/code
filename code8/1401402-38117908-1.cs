        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (this.Element != null)
            {
                this.Control.Style = Windows.UI.Xaml.Application.Current.Resources["myNewButtonStyle"] as Windows.UI.Xaml.Style;
            }
        }
