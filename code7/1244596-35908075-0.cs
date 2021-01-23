    using System.Windows;
    using System.Windows.Controls;
    namespace MyNamespace
    {
        public partial class DirectionPad : UserControl
        {
            #region Dependency Properties
            public static DependencyProperty DirectionProperty = DependencyProperty.Register("Direction", typeof(Direction), typeof(DirectionPad), new FrameworkPropertyMetadata(Direction.Origin, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnDirectionChanged));
            public Direction Direction
            {
                get
                {
                    return (Direction)GetValue(DirectionProperty);
                }
                set
                {
                    SetValue(DirectionProperty, value);
                }
            }
            private static void OnDirectionChanged(DependencyObject Object, DependencyPropertyChangedEventArgs e)
            {
                DirectionPad Pad = Object as DirectionPad;
                Pad.SetPositions(Pad.Direction);
            }
            #endregion
            #region DirectionPad
            public DirectionPad()
            {
                InitializeComponent();
            }
            #endregion
            #region Methods
            public void SetPositions(Direction Direction)
            {
                int StartRow = 0, StartColumn = 0;
                switch (Direction)
                {
                    case Direction.NW:
                        StartRow = 0;
                        StartColumn = 0;
                        break;
                    case Direction.N:
                        StartRow = 0;
                        StartColumn = 1;
                        break;
                    case Direction.NE:
                        StartRow = 0;
                        StartColumn = 2;
                        break;
                    case Direction.W:
                        StartRow = 1;
                        StartColumn = 0;
                        break;
                    case Direction.Origin:
                        StartRow = 1;
                        StartColumn = 1;
                        break;
                    case Direction.E:
                        StartRow = 1;
                        StartColumn = 2;
                        break;
                    case Direction.SW:
                        StartRow = 2;
                        StartColumn = 0;
                        break;
                    case Direction.S:
                        StartRow = 2;
                        StartColumn = 1;
                        break;
                    case Direction.SE:
                        StartRow = 2;
                        StartColumn = 2;
                        break;
                    //Direction.Origin
                }
                int i = StartRow, j = StartColumn;
                foreach (UIElement CurrentButton in this.Grid.Children)
                {
                    if (!(CurrentButton is Button)) continue;
                    if (j < StartColumn + 3)
                    {
                        Grid.SetRow(CurrentButton, i);
                        Grid.SetColumn(CurrentButton, j++);
                        if (j == (StartColumn + 3))
                        {
                            j = StartColumn;
                            i++;
                        }
                    }
                }
            }
            public void ShiftPositions(Direction Direction, int Row, int Column)
            {
                bool ShiftUp = false, ShiftDown = false, ShiftLeft = false, ShiftRight = false;
                switch (Direction)
                {
                    case Direction.NW:
                        if (Column - 1 < 0 || Row - 1 < 0) return;
                        ShiftUp = true;
                        ShiftLeft = true;
                        break;
                    case Direction.N:
                        if (Row - 1 < 0) return;
                        ShiftUp = true;
                        break;
                    case Direction.NE:
                        if (Column + 1 > 4 || Row - 1 < 0) return;
                        ShiftUp = true;
                        ShiftRight = true;
                        break;
                    case Direction.W:
                        if (Column - 1 < 0) return;
                        ShiftLeft = true;
                        break;
                    case Direction.E:
                        if (Column + 1 > 4) return;
                        ShiftRight = true;
                        break;
                    case Direction.SW:
                        if (Column - 1 < 0 || Row + 1 > 4) return;
                        ShiftDown = true;
                        ShiftLeft = true;
                        break;
                    case Direction.S:
                        if (Row + 1 > 4) return;
                        ShiftDown = true;
                        break;
                    case Direction.SE:
                        if (Column + 1 > 4 || Row + 1 > 4) return;
                        ShiftDown = true;
                        ShiftRight = true;
                        break;
                    //Direction.Origin
                    default:
                        return;
                }
                foreach (UIElement CurrentButton in this.Grid.Children)
                {
                    if (CurrentButton is Button)
                    {
                        int CurrentRow = Grid.GetRow(CurrentButton), CurrentColumn = Grid.GetColumn(CurrentButton);
                        Grid.SetRow(CurrentButton, ShiftUp ? CurrentRow - 1 : ShiftDown ? CurrentRow + 1 : CurrentRow);
                        Grid.SetColumn(CurrentButton, ShiftLeft ? CurrentColumn - 1 : ShiftRight ? CurrentColumn + 1 : CurrentColumn);
                    }
                }
                this.UpdateDirection();
            }
            public void UpdateDirection()
            {
                if (Grid.GetRow(this.OriginButton) == 1)
                {
                    if (Grid.GetColumn(this.OriginButton) == 1)
                    {
                        this.Direction = Direction.NW;
                    }
                    else if (Grid.GetColumn(this.OriginButton) == 2)
                    {
                        this.Direction = Direction.N;
                    }
                    else if (Grid.GetColumn(this.OriginButton) == 3)
                    {
                        this.Direction = Direction.NE;
                    }
                }
                else if (Grid.GetRow(this.OriginButton) == 2)
                {
                    if (Grid.GetColumn(this.OriginButton) == 1)
                    {
                        this.Direction = Direction.W;
                    }
                    else if (Grid.GetColumn(this.OriginButton) == 2)
                    {
                        this.Direction = Direction.Origin;
                    }
                    else if (Grid.GetColumn(this.OriginButton) == 3)
                    {
                        this.Direction = Direction.E;
                    }
                }
                else if (Grid.GetRow(this.OriginButton) == 3)
                {
                    if (Grid.GetColumn(this.OriginButton) == 1)
                    {
                        this.Direction = Direction.SW;
                    }
                    else if (Grid.GetColumn(this.OriginButton) == 2)
                    {
                        this.Direction = Direction.S;
                    }
                    else if (Grid.GetColumn(this.OriginButton) == 3)
                    {
                        this.Direction = Direction.SE;
                    }
                }
            }
            #endregion
            #region Events
            private void _Click(object sender, RoutedEventArgs e)
            {
                FrameworkElement Element = sender as FrameworkElement;
                int Row = Grid.GetRow(Element);
                int Column = Grid.GetColumn(Element);
                string Tag = Element.Tag.ToString();
                this.ShiftPositions(Tag.ParseEnum<Direction>(), Row, Column);
            }
            #endregion
        }
    }
