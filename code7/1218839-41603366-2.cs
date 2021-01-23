    using System;
    using System.Linq;
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    class SmartPanel : Panel
            {
                int _colCount;
                double _cellWidth;
                double[] _cellHeights;
        
        
                public static readonly DependencyProperty ItemMinWidthProperty = DependencyProperty.Register("ItemMinWidth", typeof(double), typeof(SmartPanel), new PropertyMetadata(300D));
                public double ItemMinWidth
                {
                    get { return (double)GetValue(ItemMinWidthProperty); }
                }
        
        
                public static readonly DependencyProperty MaxColumnCountProperty = DependencyProperty.Register("MaxColumnCount", typeof(int), typeof(SmartPanel), new PropertyMetadata(10));
                public int MaxColumnCount
                {
                    get { return (int)GetValue(MaxColumnCountProperty); }
                    set { SetValue(MaxColumnCountProperty, value); }
                }
        
        
                protected override Size MeasureOverride(Size availableSize)
                {
                    _colCount = (int)(availableSize.Width / ItemMinWidth);
                    if (_colCount > MaxColumnCount) _colCount = MaxColumnCount;
        
                    _cellWidth = (int)(availableSize.Width / _colCount);
        
                    var rowCount = (int)Math.Ceiling((float)Children.Count / _colCount);
        
                    _cellHeights = new double[rowCount];
        
                    var y = 0;
                    var x = 0;
                    foreach (UIElement child in Children)
                    {
                        child.Measure(new Size(_cellWidth, double.PositiveInfinity));
                        _cellHeights[y] = Math.Max(_cellHeights[y], child.DesiredSize.Height);
        
                        x++;
                        if (x >= _colCount)
                        {
                            x = 0;
                            y++;
                        }
                    }
        
                    y = 0;
                    x = 0;
                    foreach (UIElement child in Children)
                    {
                        child.Measure(new Size(_cellWidth, _cellHeights[y]));
        
                        x++;
                        if (x >= _colCount)
                        {
                            x = 0;
                            y++;
                        }
                    }
        
                    if (double.IsInfinity(availableSize.Height))
                    {
                        availableSize.Height = _cellHeights.Sum();
                    }
        
                    return availableSize;
                }
        
        
        
                protected override Size ArrangeOverride(Size finalSize)
                {
                    double x = 0;
                    double y = 0;
                    int colNum = 0;
                    int rowNum = 0;
                    foreach (UIElement child in Children)
                    {
        
                        child.Arrange(new Rect(x, y, _cellWidth, _cellHeights[rowNum]));
                        //child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                        x += _cellWidth;
                        colNum++;
        
                        if (colNum >= _colCount)
                        {
                            x = 0;
                            y += _cellHeights[rowNum];
                            colNum = 0;
                            rowNum++;
                        }
                    }
                    return finalSize;
                }
        
        
            }
