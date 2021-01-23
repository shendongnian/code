    foreach (var img in imageList) {
        var inner = new StackLayout();
        var image = new Image ();
        image.Source = img.Item1;
        image.Aspect = Aspect.AspectFill;
        var button = new Button ();
        button.Text = img.Item2;
        inner.Children.Add(image);
        inner.Children.Add(label);
        myStack.Children.Add (inner);
        button.Clicked += async (sender, e) => {
            var pg = new OtherProfilePage(img.Item1, img.Item2, img.Item3);
            await Navigation.PushModalAsync (pg);
        };
    }
