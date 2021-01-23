    public class LabelPage: ContentPage
        {
            StackLayout parent = null;
    
            public LabelPage ()
            {
                parent = new StackLayout ();
    
                Button add = new Button {
                    HorizontalOptions = LayoutOptions.End,
                    BackgroundColor = Xamarin.Forms.Color.White,
                    Text = "ADD",
                    TextColor = Xamarin.Forms.Color.Maroon,
                };
    
                add.Clicked += OnButtonClicked;
    
                Label firstLabel = new Label {
                    Text = "Label 1",
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    TextColor = Xamarin.Forms.Color.FromHex ("#000000")
                };
                parent.Children.Add (add);
                parent.Children.Add (firstLabel); 
               
                Content = parent;
            }
    
            void OnButtonClicked (object sender, EventArgs e)
            { 
                Label secondLabel = new Label {
                    Text = "Label 1",
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    TextColor = Xamarin.Forms.Color.FromHex ("#000000")
                };
                parent.Children.Add (secondLabel); 
                //UpdateChildrenLayout ();
            }
        }
