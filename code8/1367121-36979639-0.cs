    for (int i = 0; i < imagesList.Count; i++){
        var carouselChild = new ContentPage {
                Padding = padding,
                Content = new StackLayout {
                    Children = {
                        new Label {
                            Text = labelList[i],
                            FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center
                        }, 
                        new Image { Source = imagesList[i] }
                    }
                }
        };
    
        Children.Add (carouselChild);
    }
