    // Be sure to only initialise these only once (or as needed)
    // not every frame.
    //use relative path
    string dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    string filename = dir + @"\image.bmp";
    var _mytext = SharpDX.Direct3D9.Texture.FromFile(device, filename);
    var _sprite = new SharpDX.Direct3D9.Sprite(device);
    
    // Get image dimensions
    Size imageSize;
    using (var img = Image.FromFile(filename))
    {
        imageSize = img.Size;
    }
    // Calculate scale to get correct image size
    var transform = SharpDX.Matrix.AffineTransformation2D(1f, 0f, Vector2.Zero);
    // Calculate width scale
    if (imageSize.Width <= 128)
    {
        transform.M11 = (float)imageSize.Width / 128f; // scale x
    }
    else if (imageSize.Width <= 256)
    {
        transform.M11 = (float)imageSize.Width / 256f; // scale x
    }
    else if (imageSize.Width <= 512)
    {
        transform.M11 = (float)imageSize.Width / 512f; // scale x
    }
    else if (imageSize.Width <= 1024)
    {
        transform.M11 = (float)imageSize.Width / 1024f; // scale x
    }
    // Calculate height scale
    if (imageSize.Height <= 128)
    {
        transform.M22 = (float)imageSize.Height / 128f; // scale y
    }
    else if (imageSize.Height <= 256)
    {
        transform.M22 = (float)imageSize.Height / 256f; // scale y
    }
    else if (imageSize.Height <= 512)
    {
        transform.M22 = (float)imageSize.Height / 512f; // scale y
    }
    else if (imageSize.Height <= 1024)
    {
        transform.M22 = (float)imageSize.Height / 1024f; // scale y
    }
    _sprite.Transform = transform;
    float posLeft = 10f;
    float posTop = 10f;
    var pos = new SharpDX.Vector3(posLeft, posTop, 0);
    var color = new SharpDX.ColorBGRA(0xffffffff);
    _sprite.Begin(SharpDX.Direct3D9.SpriteFlags.AlphaBlend);
    _sprite.Draw(_myText, color, null, null, pos);
    _sprite.End();
