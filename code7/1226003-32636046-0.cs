    List<Image> _images = new List<Image>
    {
        img1,
        img2,
        ...
    };
    
    void Cancelar()
    {
        foreach (var image in _images)
        {
            image.Visibility = Visibility.Hidden;
        }
    }
