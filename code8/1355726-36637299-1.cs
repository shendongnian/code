    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private readonly HashSet<Int32Point> _set = new HashSet<Int32Point>();
            private readonly int columns = 10;
            private readonly int rows = 10;
            private bool _down;
            private Point _position1;
            private Point _position2;
            private Size size = new Size(500, 500);
    
            public MainWindow()
            {
                InitializeComponent();
                MouseDown += MainWindow_MouseDown;
                MouseMove += MainWindow_MouseMove;
                MouseUp += MainWindow_MouseUp;
            }
    
            private void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
            {
                _down = false;
                InvalidateVisual();
    
                // find rects selected
                var x1 = (int) Math.Floor(_position1.X/(size.Width/columns));
                var y1 = (int) Math.Floor(_position1.Y/(size.Height/rows));
                var x2 = (int) Math.Ceiling(_position2.X/(size.Width/columns));
                var y2 = (int) Math.Ceiling(_position2.Y/(size.Height/rows));
                var w = x2 - x1;
                var h = y2 - y1;
    
                var builder = new StringBuilder();
                for (var y = 0; y < h; y++)
                {
                    for (var x = 0; x < w; x++)
                    {
                        var int32Point = new Int32Point(x1 + x, y1 + y);
                        var add = _set.Add(int32Point);
                        if (add)
                        {
                            // download image !!!
                        }
                        else
                        {
                            // image already downloaded, do something !
                        }
                        builder.AppendLine(string.Format("{0} : {1}", int32Point, (add ? "added" : "ignored")));
                    }
                }
                MessageBox.Show(builder.ToString());
            }
    
            private void MainWindow_MouseMove(object sender, MouseEventArgs e)
            {
                _position2 = e.GetPosition(this);
                InvalidateVisual();
            }
    
            private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
            {
                _position1 = e.GetPosition(this);
                _down = true;
            }
    
            protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
            {
                InvalidateVisual();
            }
    
            protected override void OnRender(DrawingContext drawingContext)
            {
                // draw a mini-map
                for (var y = 0; y < rows; y++)
                {
                    for (var x = 0; x < columns; x++)
                    {
                        var color = Color.FromRgb((byte) ((double) x/columns*255), (byte) ((double) y/rows*255), 255);
                        var brush = new SolidColorBrush(color);
                        var w = size.Width/columns;
                        var h = size.Height/rows;
                        var rect = new Rect(w*x, h*y, w, h);
                        drawingContext.DrawRectangle(brush, null, rect);
                    }
                }
    
                // draw selection rectangle
                if (_down)
                {
                    drawingContext.DrawRectangle(null, new Pen(new SolidColorBrush(Colors.White), 2.0),
                        new Rect(_position1, _position2));
                }
            }
    
            private struct Int32Point
            {
                public readonly int X, Y;
    
                public Int32Point(int x, int y)
                {
                    X = x;
                    Y = y;
                }
    
                public override string ToString()
                {
                    return $"X: {X}, Y: {Y}";
                }
            }
        }
    }
