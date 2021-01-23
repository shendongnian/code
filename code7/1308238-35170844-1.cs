    public class CustomPicker2
        : Xamarin.Forms.Picker
        , ICustomPicker2
    {
        public static readonly BindableProperty MyBackgroundColorProperty = BindableProperty.Create<CustomPicker2, Xamarin.Forms.Color>(p => p.MyBackgroundColor, default(Xamarin.Forms.Color));
        public static readonly BindableProperty MyTextColorProperty = BindableProperty.Create<CustomPicker2, Xamarin.Forms.Color>(p => p.MyTextColor, default(Xamarin.Forms.Color));
        public Xamarin.Forms.Color MyTextColor
        {
            get { return (Xamarin.Forms.Color)GetValue(MyTextColorProperty); }
            set { SetValue(MyTextColorProperty, value); }
        }
        public Xamarin.Forms.Color MyBackgroundColor
        {
            get { return (Xamarin.Forms.Color)GetValue(MyBackgroundColorProperty); }
            set { SetValue(MyBackgroundColorProperty, value); }
        }
    }
