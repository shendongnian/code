    private void RotateDocumentImageSourceRight()
    {
        var biOriginal = (BitmapSource)documentImage.Source;
        if (biOriginal == null)
            return;
        var angle = 0.0;
        var biRotated = biOriginal as TransformedBitmap;
        if (biRotated != null)
        {
            biOriginal = biRotated.Source;
            angle = ((RotateTransform)biRotated.Transform).Angle;
        }
        angle -= 90;
        if (angle < 0) angle += 360;
        biRotated = new TransformedBitmap(biOriginal, new RotateTransform(angle));
        documentImage.Source = biRotated;
    }
