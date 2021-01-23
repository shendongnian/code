    List<MyUserControl> slides = new List<MyUserControl>();
    public void BtnNewSlide_OnClick(object sender, RoutedEventArgs e)
    {
        slides.Add(new MyUserControl());
        SlidesList.Items.Clear();
        SlidesList.ItemsSource = slides;     
    }
