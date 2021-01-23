    public class MyPubClass
        : Xamarin.Forms.View
    {
        public static readonly BindableProperty TheBackgroundColorProperty = BindableProperty.Create<MyPubClass, Color>(p => p.TheBackgroundColor, default(Color));
        public Color TheBackgroundColor
        {
            get { return (Color)GetValue(TheBackgroundColorProperty); }
            set { SetValue(TheBackgroundColorProperty, value); }
        }
        public MyPubClass(Color pobjColor)
        {
            this.TheBackgroundColor = pobjColor;
        }
    }
