    using (var filterEffect = new FilterEffect(source))
    {
        // Initialize the filter and add the filter to the FilterEffect collection
        var filter = new ContrastFilter(0.5);
    
        filterEffect.Filters = new IFilter[] { filter };
    
        // Create a target where the filtered image will be rendered to
        var target = new WriteableBitmap(width, height);
    
        // Create a new renderer which outputs WriteableBitmaps
        using (var renderer = new WriteableBitmapRenderer(filterEffect, target))
        {
            // Render the image with the filter(s)
            await renderer.RenderAsync();
    
            // Set the output image to Image control as a source
            ImageControl.Source = target;
        }
    
        await SaveEffectAsync(filterEffect, "ContrastFilter.jpg", outputImageSize);
    }
