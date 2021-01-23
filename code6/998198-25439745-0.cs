    public void ChangeImages()
    {           
        for (int j = 0; j < spImageList.Children.Count; j++)
        {
           Image img = (Image)Stack.FindName("img"+j.ToString());
           img.Source = new BitmapImage(new Uri("/Assets/Image/arrow_red.png", UriKind.Relative));                
        }
    }
