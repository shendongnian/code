    private CanvasRenderTarget renderTarget;
    
    private async void CanvasControl_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
    {
        args.DrawingSession.DrawImage(renderTarget);
    }
    
    private void canvasControl_CreateResources(CanvasControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
    {
        renderTarget = new CanvasRenderTarget(sender, (float)sender.ActualWidth, (float)sender.ActualHeight);
    }
    
    private List<PointerPoint> m_pt = new List<PointerPoint>();
    
    private void canvasControl_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        PointerPoint cp = e.GetCurrentPoint(canvasControl);
        m_pt.Add(cp);
        if (m_pt.Count == 2)
        {
            scrollViewer.HorizontalScrollMode = ScrollMode.Enabled;
            scrollViewer.VerticalScrollMode = ScrollMode.Enabled;
        }
    }
    
    private void canvasControl_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        if (m_pt.Count == 1)
            canvasControl.Invalidate();
        scrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
        scrollViewer.VerticalScrollMode = ScrollMode.Disabled;
        m_pt.Clear();
    }
    
    private void canvasControl_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        if (m_pt.Count == 1)
        {
            var pt = e.GetCurrentPoint(canvasControl);
            using (var ds = renderTarget.CreateDrawingSession())
            {
                ds.DrawCircle(new Vector2((float)pt.Position.X, (float)pt.Position.Y), 2, Colors.Black);
            }
        }
        else
        {
            if (m_pt.Count > 2)
                m_pt.Clear();
        }
    }
