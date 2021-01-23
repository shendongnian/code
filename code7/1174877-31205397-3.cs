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
