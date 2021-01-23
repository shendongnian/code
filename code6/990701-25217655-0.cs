    List<Testing> list = new List<Testing>();
    for (int i = 0; i < 3; i++)
    {
        Testing test = new Testing();
        test.Title = "Testing";
        var observableCollection = new ObservableCollection<FrameworkElement>();
        for (int j = 0; i < 3; i++)
        {
            observableCollection.Add(new Button { Content = j.ToString() });
            observableCollection.Add(new Canvas
            {
                Background = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(@"Assets/ApplicationIcon.png", UriKind.Relative)),
                    Stretch = System.Windows.Media.Stretch.Fill
                },
                Height = 100,
                Width = 100
            });
        }
        test.Items = observableCollection;
        list.Add(test);
    }
    listThemes.DataContext = list;
    listThemes.ItemsSource = list;
