    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace WpfApplication13
    {
        public class PanelTest : FrameworkElement
        {
            public RenderTargetBitmap _renderTargetBitmap = null;
            public System.Windows.Threading.DispatcherTimer _Timer = null;
            public int _iYLoc = 0;
            private Pen _pen = null;
    
            protected override void OnRender(DrawingContext drawingContext)
            {
                if (!DesignerProperties.GetIsInDesignMode(this))
                {
                    drawingContext.DrawImage(_renderTargetBitmap, new Rect(0, 0, 250, 250));
                }
    
            
                base.OnRender(drawingContext);
            }
    
            public PanelTest() :base()
            {
                _renderTargetBitmap = new RenderTargetBitmap(250, 250, 96, 96, System.Windows.Media.PixelFormats.Pbgra32);
                _pen = new Pen(Brushes.Red, 1);
                _Timer = new System.Windows.Threading.DispatcherTimer();
                _Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                _Timer.Tick += _Timer_Tick;
                if (!DesignerProperties.GetIsInDesignMode(this))
                {
                    _Timer.Start();
                }
            }
    
            private void _Timer_Tick(object sender, EventArgs e)
            {
    
                DrawingVisual vis = new DrawingVisual();
                DrawingContext con = vis.RenderOpen();
                con.DrawLine(_pen, new Point(0, _iYLoc), new Point(250, _iYLoc));
                _iYLoc++;
    
                con.Close();
    
                _renderTargetBitmap.Render(vis);
            }
        }
        
    }
