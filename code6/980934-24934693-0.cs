        public static void ExportToImage(Canvas canvas)
        {
            
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.DefaultExt = "png";
            dlg.FilterIndex = 2;
            dlg.FileName = "DesignerImage.png";
            dlg.RestoreDirectory = true;
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            string path = dlg.FileName;
            int selectedFilterIndex = dlg.FilterIndex;
            if(result==true)
            {
                try
                {
                    RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                             (int)canvas.ActualWidth, (int)canvas.ActualHeight,
                              96d, 96d, PixelFormats.Pbgra32);
                    // needed otherwise the image output is black
                    canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
                    canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));
                    renderBitmap.Render(canvas);
                    BitmapEncoder imageEncoder = new PngBitmapEncoder();
                    if (selectedFilterIndex == 0)
                    {
                    }
                    else if (selectedFilterIndex == 1)
                    {
                        imageEncoder = new JpegBitmapEncoder();
                    }
                    else if (selectedFilterIndex == 2)
                    {
                        imageEncoder = new PngBitmapEncoder();
                    }
                    else if (selectedFilterIndex == 3)
                    {
                        imageEncoder = new JpegBitmapEncoder();
                    }
                    else if (selectedFilterIndex == 4)
                    {
                        imageEncoder = new GifBitmapEncoder();
                    }
                    imageEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                   
                    using (FileStream file = File.Create(path))
                    {
                        imageEncoder.Save(file);
        
                    }
                }
                catch (Exception ex)
                {
                }
     
         }
        }
