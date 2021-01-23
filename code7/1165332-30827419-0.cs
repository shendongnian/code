    public class MenuCell : ViewCell
    {
        public MenuCell()
        {
            Label objLabel = new Label
            {
                YAlign = TextAlignment.Center,
                TextColor = Color.Yellow,                
            };
            objLabel.SetBinding(Label.TextProperty, new Binding("."));
            StackLayout objLayout = new StackLayout
            {
                Padding = new Thickness(20, 0, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { objLabel }
            };
            
            Frame objFrame_Inner = new Frame
            {
                Padding = new Thickness(15, 15, 15, 15),
                HeightRequest = 36,
                OutlineColor = Color.Accent,
                BackgroundColor = Color.Blue,
                Content = objLayout,                
            };
            Frame objFrame_Outer = new Frame
            {
                Padding = new Thickness(0, 0, 0, 10),
                Content = objFrame_Inner
            };
            View = objFrame_Outer;            
        }
    }
