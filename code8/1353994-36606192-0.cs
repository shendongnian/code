            Size size = new Size(mcChart.ActualWidth, mcChart.ActualHeight);
            if (size.IsEmpty)
                return;
            size.Height *= 2;
            size.Width *= 2;
            RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
            DrawingVisual drawingvisual = new DrawingVisual();
            using (DrawingContext context = drawingvisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(mcChart), null, new Rect(new Point(), size));
                context.Close();
            }
            result.Render(drawingvisual);
            string filename = "test.png";
            FileStream fout = new FileStream(filename, FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(result));
            encoder.Save(fout);
            fout.Close();
            MessageBox.Show("Done");
