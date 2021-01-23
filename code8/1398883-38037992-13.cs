    using (var bmp = new Bitmap(794, 1122))
    using (var graphics = Graphics.FromImage(bmp))
    using (var metafile = Metafile.FromFile(@"drawing.wmf"))
    using (var imageAttr = new ImageAttributes())
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        
        var metafileHandleField = typeof(Metafile).GetField("nativeImage", BindingFlags.Instance | BindingFlags.NonPublic);
        var imageAttributesHandleField = typeof(ImageAttributes).GetField("nativeImageAttributes", BindingFlags.Instance | BindingFlags.NonPublic);
        var graphicsHandleProperty = typeof(Graphics).GetProperty("NativeGraphics", BindingFlags.Instance | BindingFlags.NonPublic);
        var setNativeImage = typeof(Image).GetMethod("SetNativeImage", BindingFlags.Instance | BindingFlags.NonPublic);
        IntPtr mf = (IntPtr)metafileHandleField.GetValue(metafile);
        IntPtr ia = (IntPtr)imageAttributesHandleField.GetValue(imageAttr);
        IntPtr g = (IntPtr)graphicsHandleProperty.GetValue(graphics);
        Boolean isSuccess;
        IntPtr emfPlusHandle;
        var status = GdipConvertToEmfPlus(new HandleRef(graphics, g),
                                          new HandleRef(metafile, mf),
                                          out isSuccess,
                                          EmfType.EmfPlusOnly,
                                          "",
                                          out emfPlusHandle);
        if (status != 0)
        {
            throw new Exception("Can't convert");
        }
        using (var emfPlus = (Metafile)System.Runtime.Serialization.FormatterServices.GetSafeUninitializedObject(typeof(Metafile)))
        {
            setNativeImage.Invoke(emfPlus, new object[] { emfPlusHandle });
            // use EnumerateMetafile on emfPlus as per your example code or save it:
            emfPlus.Save(@"drawing.emf");
        }
    }
