    private Lazy<ImageSource > _image=new Lazy<ImageSource>(()=>imageFromBase64());
    public ImageSource logo
    {
        get { return _image.Value; }
    }
    private string _logoBase64;
    public string logoBase64
    {
        get { return _logoBase64; }
        set
        {
            _logoBase64 = value;
            //Can't reset a Lazy, so we create a new one.
            _image=new Lazy<ImageSource>(()=>imageFromBase64()));
        }
    }
    ImageSource imageFromBase64()
    {
       var image = new BitmapImage(); 
       if ((b64 != null) && (b64.Length > 0))
       {
                b64 = b64
                    .Replace("data:image/png;base64,", "")
                    .Replace("data:image/gif;base64,", "")
                    .Replace("data:image/jpeg;base64,", "");
                try
                {
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(Convert.FromBase64String(b64));
                    image.EndInit();
                }
                catch (Exception e)
                {
                    Program.Errors.Add(e.Message + "\n" + e.StackTrace);
                    if (Program.environment == "development")
                    {
                        Console.WriteLine(e.Message);
                    }
                }
        }
        return image;
    }
