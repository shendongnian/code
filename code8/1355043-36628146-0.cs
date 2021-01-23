    using System;
    using Xamarin.Forms;
    namespace FormsSandbox
    {
        public class MyView : ContentView
        {
            public static BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(MyView), 
                String.Empty, BindingMode.Default, null, TextChanged);
            public string Text {
                get {
                    return (string)GetValue (TextProperty);
                }
                set {
                    SetValue (TextProperty, value);
                }
            }
            private Label _contentLabel;
            public MyView ()
            {
                _contentLabel = new Label {
                    FontSize = 56,
                    FontAttributes = FontAttributes.Bold,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Content = _contentLabel;
            }
            static void TextChanged (BindableObject bindable, object oldValue, object newValue)
            {
                var view = (MyView)bindable;
                view._contentLabel.Text = (newValue ?? "").ToString ();
            }
        }
    }
