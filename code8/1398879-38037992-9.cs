    Graphics graphics;
    Metafile metafile;
    ImageAttributes imageAttr;
    var metafileHandleField = typeof(Metafile).GetField("nativeImage", BindingFlags.Instance | BindingFlags.NonPublic);
    var imageAttributesHandleField = typeof(ImageAttributes).GetField("nativeImageAttributes", BindingFlags.Instance | BindingFlags.NonPublic);
    var graphicsHandleProperty = typeof(Graphics).GetProperty("NativeGraphics", BindingFlags.Instance | BindingFlags.NonPublic);
    IntPtr mf = (IntPtr)metafileHandleField.GetValue(metafile);
    IntPtr ia = (IntPtr)imageAttributesHandleField.GetValue(imageAttr);
    IntPtr g = (IntPtr)graphicsHandleProperty.GetValue(graphics);
    bool isSuccess;
    IntPtr emfPlusHandle;
    var status = GdipConvertToEmfPlus(new HandleRef(graphics, g),
                                      new HandleRef(metafile, mf),
                                      out isSuccess,
                                      EmfType.EmfPlusDual,
                                      "",
                                      out emfPlusHandle);
    var emfPlus = new Metafile(emfPlusHandle, new WmfPlaceableFileHeader());
    // use EnumerateMetafile on emfPlus as per your example code
