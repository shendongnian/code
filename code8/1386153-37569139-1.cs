    public class Page1 : ContentPage
        {
            public Page1()
            {
                BindingContext = new ThingsObject();
                var lbl = new Label();
                lbl.SetBinding(Label.TextProperty, "Number");
                Content = new StackLayout
                {
                    Children = {
                        lbl
                    }
                };
            }
        }
