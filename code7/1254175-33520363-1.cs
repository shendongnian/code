    public string logoBase64
    {
        get { return _logoBase64; }
        set
        {
            _logoBase64 = value;
            //Can't reset a Lazy, so we create a new one.
            var newLazy=new Lazy<ImageSource>(()=>imageFromBase64()));
            //Start throwaway task before assigning to backing field,
            //to avoid race conditions
            Task.Run(()=>newLazy.Value);
            _image=newLazy;
        }
    }
