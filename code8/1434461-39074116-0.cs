    public class BasePage : ContentPage
    {
        public static readonly BindableProperty BarTextColorProperty =
            BindableProperty.Create(nameof(BarTextColor),
                                    typeof(Color),
                                    typeof(BasePage),
                                    Color.White,
                                    propertyChanged: OnColorChanged);
        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
        public Color BarTextColor
        {
            get { return (Color)GetValue(BarTextColorProperty); }
            set { SetValue(BarTextColorProperty, value); }
        }
    }
