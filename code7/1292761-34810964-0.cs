    public void makeImage(vtkRenderWindow window, vtkRenderer renderer,string filePrefix="")
    {
        if (_parts.Count == 0)
            return;
        // Make cameras
        Cameras cameras = new Cameras(_axial, _coronal, _sagittal, _parts[0].center, _parts[0].zoomfactor);
        foreach (string camName in cameraNames)
        {
            vtkCamera cam = cameras.getCameraByName(camName);
            if (cam == null)
                continue;
            // Skip already created screenshots
            if (File.Exists(getFilename(camName, filePrefix)))
                continue;
            // Clear renderer
            renderer.RemoveAllViewProps();
            // Show parts
            this.show(renderer);
            // Set camera
            renderer.SetActiveCamera(cam);
            renderer.GetActiveCamera().SetClippingRange(1.0, 1000);
            window.Render();
            // Update window to image filter
            vtkWindowToImageFilter windowToImageFilter = vtkWindowToImageFilter.New();
            windowToImageFilter.SetMagnification(4); // set the resolution of the output image (3 times the current resolution of vtk render window)
            windowToImageFilter.SetInput(window);
                
            // Write to png
            vtkPNGWriter writer = vtkPNGWriter.New();
            writer.SetInputConnection(windowToImageFilter.GetOutputPort());
            writer.SetFileName(tempFile);
            writer.Write();
            // Dispose pipeline parts
            windowToImageFilter.Dispose();
            writer.Dispose();
            // Crop png image
            Bitmap img = new Bitmap(tempFile);
            Bitmap imgCrop = cropImage(img, squareImages);
            imgCrop.MakeTransparent(Color.White);
            imgCrop.Save(getFilename(camName,filePrefix));
            // Dispose images (necessary to avoid memory filling)
            img.Dispose();
            imgCrop.Dispose();
            // Delete temporary file
            File.Delete(tempFile);
        }
    }
