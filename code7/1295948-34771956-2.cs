    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public partial class MyTableControl
        {
            private const int MinColumns = 1;
            private const int MaxColumns = 10;
            private const int MinRows = 1;
            private const int MaxRows = 10;
    
            public static readonly DependencyProperty RowsProperty = DependencyProperty.Register(
                "Rows", typeof (int), typeof (MyTableControl), new PropertyMetadata(MinRows, OnRowsChanged, OnRowsCoerce));
    
            public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
                "Columns", typeof (int), typeof (MyTableControl),
                new PropertyMetadata(MinColumns, OnColumnsChanged, OnColumnsCoerce));
    
            private bool _pressed;
            
            public MyTableControl()
            {
                InitializeComponent();
                Columns = 5;
                Rows = 5;
            }
    
            public int Rows
            {
                get { return (int) GetValue(RowsProperty); }
                set { SetValue(RowsProperty, value); }
            }
    
            public int Columns
            {
                get { return (int) GetValue(ColumnsProperty); }
                set { SetValue(ColumnsProperty, value); }
            }
    
            private static object OnRowsCoerce(DependencyObject d, object basevalue)
            {
                var i = (int) basevalue;
                return i < MinRows ? MinRows : i > MaxRows ? MaxRows : i;
            }
    
            private static object OnColumnsCoerce(DependencyObject d, object basevalue)
            {
                var i = (int) basevalue;
                return i < MinColumns ? MinColumns : i > MaxColumns ? MaxColumns : i;
            }
    
            private static void OnRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control1 = (MyTableControl) d;
                control1.Populate();
            }
    
            private static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control1 = (MyTableControl) d;
                control1.Populate();
            }
    
            private void Populate()
            {
                root.Children.Clear();
                root.Columns = Columns;
                root.Rows = Rows;
                for (var y = 0; y < Rows; y++)
                {
                    for (var x = 0; x < Columns; x++)
                    {
                        var toggleButton = new ToggleButton {Tag = new Point(x, y)};
                        toggleButton.MouseEnter += ToggleButton_MouseEnter;
                        toggleButton.Click += ToggleButton_Click;
                        root.Children.Add(toggleButton);
                    }
                }
            }
    
            private void ToggleButton_Click(object sender, RoutedEventArgs e)
            {
                _pressed = true; // stops selection
                // little bug here, button will be unchecked since it is a toggle button
                // but since you'll use images instead, this behavior will vanish
            }
    
            private void ToggleButton_MouseEnter(object sender, MouseEventArgs e)
            {
                if (_pressed)
                {
                    return;
                }
    
                var button = (ToggleButton) sender;
                var point = (Point) button.Tag;
                var x = (int) point.X;
                var y = (int) point.Y;
    
                for (var i = 0; i < Columns*Rows; i++)
                {
                    var element = (ToggleButton) root.Children[i];
                    var tag = (Point) element.Tag;
                    var x1 = (int) tag.X;
                    var y1 = (int) tag.Y;
                    element.IsChecked = x1 <= x && y1 <= y;
                }
            }
        }
    }
