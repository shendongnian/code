    private void SetHighLight()
    {
        InkDrawingAttributes attributes = new InkDrawingAttributes();
        attributes.PenTip = PenTipShape.Rectangle;
        attributes.Size = new Size(4, 10);
        attributes.Color = currentColor;
        SetAttribute(attributes);
    }
    private void GetCanvasRender(out CanvasRenderTarget renderTarget, float opacity)
    {
        CanvasDevice device = CanvasDevice.GetSharedDevice();
        renderTarget = new CanvasRenderTarget(device, (int)ink.ActualWidth, (int)ink.ActualHeight, 96);
        using (var ds = renderTarget.CreateDrawingSession())
        {
            ds.Clear(Colors.Transparent);
            using (ds.CreateLayer(opacity))
            {
                ds.DrawInk(ink.InkPresenter.StrokeContainer.GetStrokes());
            }
        }
    }
    private async void SavePicture(float opacity)
    {
        CanvasRenderTarget renderTarget;
        Image img = new Image();
        GetCanvasRender(out renderTarget, opacity);
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        StorageFile noteFile = await storageFolder.CreateFileAsync(i.ToString() + ".png", CreationCollisionOption.ReplaceExisting);
        using (var fileStream = await noteFile.OpenAsync(FileAccessMode.ReadWrite))
            await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Png, 1f);
        img.Source = new BitmapImage(new Uri(storageFolder.Path + "/" + i++ + ".png"));
        img.VerticalAlignment = VerticalAlignment.Stretch;
        ContainerCanvas.Children.Add(img);
        Canvas.SetTop(img, ScrollViewerContainer.VerticalOffset);
        Canvas.SetZIndex(img, 5);
    }
