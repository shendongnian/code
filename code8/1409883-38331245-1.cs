    ObservableCollection<ImageSourceClass> flipviewCollection = new ObservableCollection<ImageSourceClass>();
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        flipviewCollection.Clear();
        flipviewCollection.Add(new ImageSourceClass { ImageSource = "Assets/1.jpg" });
        flipviewCollection.Add(new ImageSourceClass { ImageSource = "Assets/2.jpg" });
        flipviewCollection.Add(new ImageSourceClass { ImageSource = "Assets/3.jpg" });
        flipviewCollection.Add(new ImageSourceClass { ImageSource = "Assets/4.jpg" });
        flipviewCollection.Add(new ImageSourceClass { ImageSource = "Assets/5.jpg" });
    }
