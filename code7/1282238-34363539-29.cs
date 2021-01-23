    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            Polyline _baseLine;
            Polyline _highlightLine;
            Point _currentPoint;
            bool _newLine;
    
            Dictionary<Polyline, Polyline> _lines = new Dictionary<Polyline, Polyline>();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
                _newLine = true;
            }
    
            private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
            {
                if (_highlightLine != null  && !_newline)
                {
                    _highlightLine.MouseEnter += ShowHighlight;
                    _highlightLine.MouseLeave += HideHighlight;
                }
            }
    
            private void Canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (_newLine)
                    {
                        _baseLine = new Polyline
                        {
                            Stroke = SystemColors.WindowFrameBrush,
                            StrokeThickness = 1.0
                        };
                        _highlightLine = new Polyline
                        {
                            Opacity = 0.0,
                            Stroke = SystemColors.WindowFrameBrush,
                            StrokeThickness = 10.0
                        };
    
                        paintSurface.Children.Add(_baseLine);
                        paintSurface.Children.Add(_highlightLine);
                        _lines.Add(_highlightLine, _baseLine);
                        _newLine = false;
                    }
    
                    _currentPoint = e.GetPosition(this);
                    _baseLine.Points.Add(_currentPoint);
                    _highlightLine.Points.Add(_currentPoint);
                }
            }
    
            private void ShowHighlight(object sender, MouseEventArgs e)
            {
                var line = sender as Polyline;
                if (line != null)
                {
                    _lines[line].Stroke = new SolidColorBrush(Colors.LimeGreen);
                }
            }
    
            private void HideHighlight(object sender, MouseEventArgs e)
            {
                var line = sender as Polyline;
                if (line != null)
                {
                    _lines[line].Stroke = SystemColors.WindowFrameBrush;
                }
            }
        }
    }
