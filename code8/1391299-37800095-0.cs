    public partial class ButtonWithAnim : Button
    {
        public Grid GridToFadeOut
        {
            get { return (Grid)GetValue(GridToFadeOutProperty); }
            set { SetValue(GridToFadeOutProperty, value); }
        }
        // Using a DependencyProperty as the backing store for GridToFadeOut.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridToFadeOutProperty =
            DependencyProperty.Register("GridToFadeOut", typeof(Grid), typeof(ButtonWithAnim));
        public Grid GridToFadeIn
        {
            get { return (Grid)GetValue(GridToFadeInProperty); }
            set { SetValue(GridToFadeInProperty, value); }
        }
        // Using a DependencyProperty as the backing store for GridToFadeIn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GridToFadeInProperty =
            DependencyProperty.Register("GridToFadeIn", typeof(Grid), typeof(ButtonWithAnim));
        protected override void OnClick()
        {
            ButtonClickHandler();
        }
        public void ButtonClickHandler()
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation(1.0, 0.0, new TimeSpan(0, 0, 0, 0, 250));
            DoubleAnimation fadeInAnimation  = new DoubleAnimation(0.0, 1.0, new TimeSpan(0, 0, 0, 0, 250));
            fadeOutAnimation.Completed += (sender, eArgs) =>
            {
                GridToFadeOut.Visibility = Visibility.Collapsed;
                GridToFadeIn.Visibility = Visibility.Visible;
                GridToFadeIn.BeginAnimation(Grid.OpacityProperty, fadeInAnimation);
            };
            GridToFadeOut.BeginAnimation(Grid.OpacityProperty, fadeOutAnimation);
        }
    }
