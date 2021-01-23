    static ImageOrientation GetOrientation(this Image image)
    {
        PropertyItem pi = SafeGetPropertyItem(image, 0x112);
        if (pi == null || pi.Type != 3)
        {
            return ImageOrientation.Original;
        }
        return (ImageOrientation)BitConverter.ToInt16(pi.Value, 0);
    }
    // A file without the desired EXIF property record will throw ArgumentException.
    static PropertyItem SafeGetPropertyItem(Image image, int propid)
    {
        try
        {
            return image.GetPropertyItem(propid);
        }
        catch (ArgumentException)
        {
            return null;
        }
    }
