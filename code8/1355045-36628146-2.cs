    using System;
    using Xamarin.Forms;
    namespace FormsSandbox
    {
        public partial class XamlPage : ContentPage
        {
            public XamlPage ()
            {
                InitializeComponent ();
                SelectButton (Button1);
            }
            void SelectButton(Button button)
            {
                View view = null;
                if (button == Button1)
                    view = View1;
                if (button == Button2)
                    view = View2;
                if (button == Button3)
                    view = View3;
                View1.IsVisible = View1 == view;
                View2.IsVisible = View2 == view;
                View3.IsVisible = View3 == view;
                Button1.TextColor = (Button1 == button) ? Color.Accent.AddLuminosity(0.18) : (Color)Button.TextColorProperty.DefaultValue;
                Button2.TextColor = (Button2 == button) ? Color.Accent.AddLuminosity(0.18) : (Color)Button.TextColorProperty.DefaultValue;
                Button3.TextColor = (Button3 == button) ? Color.Accent.AddLuminosity(0.18) : (Color)Button.TextColorProperty.DefaultValue;
                Button1.BackgroundColor = (Button1 == button) ? Color.Silver.AddLuminosity(0.18) : Color.Silver.AddLuminosity(0.1);
                Button2.BackgroundColor = (Button2 == button) ? Color.Silver.AddLuminosity(0.18) : Color.Silver.AddLuminosity(0.1);
                Button3.BackgroundColor = (Button3 == button) ? Color.Silver.AddLuminosity(0.18) : Color.Silver.AddLuminosity(0.1);
            }
            void ButtonClicked (object sender, EventArgs e)
            {
                SelectButton ((Button)sender);
            }
        }
    }
