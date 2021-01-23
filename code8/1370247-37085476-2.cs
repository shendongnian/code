    private string imageBase64
    public string ImageBase64
    {
        get { return imageBase64; }
        set
        {
            imageBase64 = value;
            OnPropertyChanged("ImageBase64");
            OnPropertyChanged("Image");
        } 
    }
    private Xamarin.Forms.ImageSource image;
    public Xamarin.Forms.ImageSource Image
    {
        get
        {
            if (image == null)
            {
                image = Xamarin.Forms.ImageSource.FromStream(
                    () => new MemoryStream(Convert.FromBase64String(ImageBase64)));
            }
            return image;
        }
    }
