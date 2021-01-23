    class LED{
       /*
        I used NULL instead of Global.DefaultBitmap, which worked just fine
        if you don't leave lose ends, but these classes are actually
        Controls and the UserControl test container kept giving me errors
        when I scrolled through base control, so I decided to add a static
        10x10 image/icon to all base controls to have that instead of errors.
       */
       public virtual Bitmap bmp {get {return Global.DefaultBitmap;} set{}}
       public LED(){}
    }
    class LEDa : LED{ //code is identical in LEDb
       static Bitmap _bmp;
       public override Bitmap bmp{get{return _bmp;}set{_bmp=value}}
       public LEDa(){}
    }
