    CanvasDevice device = CanvasDevice.GetSharedDevice();
    CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)inkCanvas.ActualWidth, (int)inkCanvas.ActualHeight, 96);
    using (var ds = renderTarget.CreateDrawingSession())
    {
        ds.Clear(Colors.White);
        ds.DrawInk(inkCanvas.InkPresenter.StrokeContainer.GetStrokes());
    }
    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
        await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Jpeg, 1f);
