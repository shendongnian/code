    public Dictionary<string, string> imageList = new Dictionary<string,string> ();
    
    async void loadImages ()
    {
        var getImages = await phpApi.getImages ();
    
        foreach (var theitems in getImages ["results"])
        {
            imageList.Add(
              theitems ["Photo"].ToString(),
              theitems ["PhotoName"].ToString()
            );
    
        }
    
        foreach (var key in imageList.Keys) {
            // vertical stack for each image/label pair
            var inner = new StackLayout();
    
            var image = new Image ();
            image.Source = key;
            image.Aspect = Aspect.AspectFill;
    
            var label = new Label ();
            label.Text = imageList [key];
            
            inner.Children.Add(image);
            inner.Children.Add(label);
            myStack.Children.Add (inner);
    
        }
    
    }
