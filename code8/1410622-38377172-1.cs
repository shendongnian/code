    public class ToggleBehavior : Behavior<View>
    {
        readonly TapGestureRecognizer tapRecognizer;
        public ToggleBehavior()
        {
            tapRecognizer = new TapGestureRecognizer
            {
                Command = new Command(() => this.IsToggled = !this.IsToggled)
            };
        }
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create<ToggleBehavior, bool>(tb => tb.IsToggled, false);
        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }
        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.GestureRecognizers.Add(this.tapRecognizer);
        }
        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.GestureRecognizers.Remove(this.tapRecognizer);
        }
    }
