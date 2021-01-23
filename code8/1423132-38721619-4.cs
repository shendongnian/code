    using System.Collections.Generic;
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Documents;
    namespace ReadableBlockDemo.Controls {
        public sealed class ReadableBlock : ContentControl {
            public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ReadableBlock), null);
            public static readonly DependencyProperty TextAlignmentProperty =
                DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(ReadableBlock), new PropertyMetadata(TextAlignment.Left));
            public static readonly DependencyProperty ColumnsProperty =
                DependencyProperty.Register("Columns", typeof(int), typeof(ReadableBlock), new PropertyMetadata(1));
            public static readonly DependencyProperty ColumnSpacingProperty =
                DependencyProperty.Register("ColumnSpacing", typeof(double), typeof(ReadableBlock), new PropertyMetadata(10d));
            public string Text {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
            public TextAlignment TextAlignment {
                get { return (TextAlignment)GetValue(TextAlignmentProperty); }
                set { SetValue(TextAlignmentProperty, value); }
            }
            public int Columns {
                get { return (int)GetValue(ColumnsProperty); }
                set { SetValue(ColumnsProperty, (int)value); }
            }
            public double ColumnSpacing {
                get { return (double)GetValue(ColumnSpacingProperty); }
                set { SetValue(ColumnSpacingProperty, (double)value); }
            }
            public new string Content {
                get { return (string)GetValue(ContentProperty); }
                set { base.Content = null; SetValue(ContentProperty, Text = (string)value); RenderText(); }
            }
            private StackPanel Container => base.Content as StackPanel;
            private double AvailableWidth;
            private double AvailableHeight;
            private TextBlock[] Blocks;
            private double ColumnWidth;
            private bool IsTextRenderingAvailable;
            public ReadableBlock() {
                Loaded += ReadableBlock_Loaded;
            }
            private void ReadableBlock_Loaded(object sender, RoutedEventArgs e) {
                LayoutUpdated += ReadableBlock_LayoutUpdated;
                InvalidateArrange();
            }
            private void ReadableBlock_LayoutUpdated(object sender, object e) {
                if (ActualWidth != AvailableWidth || ActualHeight != AvailableHeight) OnAvailableSizeChanged();
            }
            private void OnAvailableSizeChanged() {
                IsTextRenderingAvailable = true;
                AvailableWidth = ActualWidth;
                AvailableHeight = ActualHeight;
                double n = Columns;
                double s = ColumnSpacing;
                ColumnWidth = (AvailableWidth - ((n - 1d) * s)) / n;
                if (Blocks == null) CreateColumns();
                RenderText();
            }
            private void CreateColumns() {
                var container = new StackPanel { Orientation = Orientation.Horizontal };
                var columns = Columns;
                var spacing = ColumnSpacing;
                var blocks = new List<TextBlock>();
                TextBlock block;
                for (int i = 0; i < columns; i++) {
                    blocks.Add(block = new TextBlock { TextWrapping = TextWrapping.Wrap, TextAlignment = TextAlignment, Width = ColumnWidth, Height = AvailableHeight });
                    if (i > 0) block.Margin = new Thickness(spacing, 0, 0, 0);
                    container.Children.Add(block);
                }
                base.Content = container;
                Blocks = blocks.ToArray();
            }
            private int GetSplitOffset(string text) {
                var m = new TextBlock { FontFamily = FontFamily, FontSize = FontSize, TextWrapping = TextWrapping.Wrap, TextAlignment = TextAlignment };
                m.Text = text;
                m.Measure(new Size(ColumnWidth, double.PositiveInfinity));
                if (m.DesiredSize.Height < AvailableHeight) return -1;
                var p = m.ContentStart;
                var r = p.GetCharacterRect(LogicalDirection.Forward);
                for (int i = 0, l = text.Length; i < l && r.Bottom < AvailableHeight; i++) {
                    p = p.GetPositionAtOffset(1, LogicalDirection.Forward);
                    r = p.GetCharacterRect(LogicalDirection.Forward);
                }
                return p.Offset - 2;
            }
            private bool SetBlock(int i, string text) {
                if (i >= Blocks.Length) return false;
                var block = Blocks[i];
                block.Width = ColumnWidth;
                block.Height = AvailableHeight;
                block.Text = text;
                return true;
            }
            private void RenderText() {
                if (!IsTextRenderingAvailable || Text == null) return;
                int i = 0, splitOffset = 0, n = Blocks.Length;
                string text = Text;
                for (i = 0; i < n; i++) Blocks[i].Text = "";
                for (i = 0; i < n; i++) {
                    splitOffset = GetSplitOffset(text);
                    if (splitOffset > 0) {
                        if (!SetBlock(i, text.Substring(0, splitOffset))) return;
                        if (!SetBlock(i + 1, text = text.Substring(splitOffset))) return;
                    }
                    else {
                        SetBlock(i, text);
                        return;
                    }
                }
            }
        }
    }
