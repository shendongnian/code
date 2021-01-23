    private string imageBase64
    public string ImageBase64
    {
        get { return imageBase64; }
        set
        {
            imageBase64 = value;
            Image = Xamarin.Forms.ImageSource.FromStream(
                () => new MemoryStream(Convert.FromBase64String(imageBase64)));
            OnPropertyChanged("ImageBase64");
        } 
    }
    private Xamarin.Forms.ImageSource image;
    public Xamarin.Forms.ImageSource Image
    {
        get { return image; }
        set
        {
            image = value;
            OnPropertyChanged("Image");
        }
    }
