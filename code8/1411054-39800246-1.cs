            private bool _imageLoaded;
        // this is an initial way of handling resize 
        // I will investigate expressions
        private async void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (!_imageLoaded)
            {
                return;
            }
            await RenderOverlayAsync();
        }
        private async void ImageBrush_OnImageOpened(object sender, RoutedEventArgs e)
        {
            _imageLoaded = true;
            await RenderOverlayAsync();
        }
        // this method must be called after the background image is opened, otherwise
        // the render target bitmap is empty
        private async Task RenderOverlayAsync()
        {
            // setup composition
            // (in line here for readability - will be member variables moving forwards)
            var compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            var canvasDevice = new CanvasDevice();
            var compositionDevice = CanvasComposition.CreateCompositionGraphicsDevice(compositor, canvasDevice);
            // determine what region of the background we need to "cut out" for the overlay
            GeneralTransform gt = Posters.TransformToVisual(LayoutRoot);
            Point elementPosition = gt.TransformPoint(new Point(0, 0));
            // our overlay height is as wide as our poster control and is 30 px high
            var overlayHeight = 30;
            var areaToRender = new Rect(elementPosition.X, elementPosition.Y, Posters.ActualWidth, overlayHeight);
            // Capture the image from our background.
            //
            // Note: this is just the <Image/> element, not the Grid. If we took the <Grid/>, 
            // we would also have all of the child elements, such as the <GridView/> rendered as well -
            // which defeats the purpose!
            // 
            // Note 2: this method must be called after the background image is opened, otherwise
            // the render target bitmap is empty
            var bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(BackgroundImage);
            var pixels = await bitmap.GetPixelsAsync();
            // we need the display DPI so we know how to handle the bitmap correctly when we render it
            var dpi = DisplayInformation.GetForCurrentView().LogicalDpi;
            // load the pixels from RenderTargetBitmap onto a CompositionDrawingSurface
            CompositionDrawingSurface uiElementBitmapSurface;
            using (
                // this is the entire background image
                // Note we are using the display DPI here.
                var canvasBitmap = CanvasBitmap.CreateFromBytes(
                    canvasDevice, pixels.ToArray(),
                    bitmap.PixelWidth,
                    bitmap.PixelHeight,
                    DirectXPixelFormat.B8G8R8A8UIntNormalized,
                    dpi)
            )
            {
                // we create a surface we can draw on in memory.
                // note we are using the desired size of our overlay
                uiElementBitmapSurface =
                    compositionDevice.CreateDrawingSurface(
                        new Size(areaToRender.Width, areaToRender.Height),
                        DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied);
                using (var session = CanvasComposition.CreateDrawingSession(uiElementBitmapSurface))
                {
                    // here we draw just the part of the background image we wish to use to overlay
                    session.DrawImage(canvasBitmap, 0, 0, areaToRender);
                }
            }
            // assign CompositionDrawingSurface to the CompositionSurfacebrush with which I want to paint the relevant SpriteVisual
            var backgroundImageBrush = _compositor.CreateSurfaceBrush(uiElementBitmapSurface);
            // load in our opacity mask image.
            // this is created in a graphic tool such as paint.net
            var opacityMaskSurface = await SurfaceLoader.LoadFromUri(new Uri("ms-appx:///Assets/OpacityMask.Png"));
            // create surfacebrush with ICompositionSurface that contains the background image to be masked
            backgroundImageBrush.Stretch = CompositionStretch.UniformToFill;
            // create surfacebrush with ICompositionSurface that contains the gradient opacity mask asset
            CompositionSurfaceBrush opacityBrush = _compositor.CreateSurfaceBrush(opacityMaskSurface);
            opacityBrush.Stretch = CompositionStretch.UniformToFill;
            // create maskbrush
            CompositionMaskBrush maskbrush = _compositor.CreateMaskBrush();
            maskbrush.Mask = opacityBrush; // surfacebrush with gradient opacity mask asset
            maskbrush.Source = backgroundImageBrush; // surfacebrush with background image that is to be masked
            // create spritevisual of the approproate size, offset, etc.
            SpriteVisual maskSprite = _compositor.CreateSpriteVisual();
            maskSprite.Size = new Vector2((float)Posters.ActualWidth, overlayHeight);
            maskSprite.Brush = maskbrush; // paint it with the maskbrush
            // set the sprite visual as a child of the XAML element it needs to be drawn on top of
            ElementCompositionPreview.SetElementChildVisual(Posters, maskSprite);
        }
