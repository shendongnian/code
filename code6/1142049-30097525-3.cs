    var w = 4000;
    var h = 4000;
    var screen = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
    var visual = new DrawingVisual();
    using (var context = visual.RenderOpen())
    {
    	context.DrawRectangle(new VisualBrush(screen),
                              null,
    	                      new Rect(new Point(), new Size(screen.Width, screen.Height)));
    }
     visual.Transform = new ScaleTransform(w / screen.ActualWidth, h / screen.ActualHeight);
     var rtb = new RenderTargetBitmap(w, h, 96, 96, PixelFormats.Pbgra32);
     rtb.Render(visual);
     var enc = new PngBitmapEncoder();
     enc.Frames.Add(BitmapFrame.Create(rtb));
     using (var stm = File.Create("ScreenShot.png"))
     {
         enc.Save(stm);
     }
