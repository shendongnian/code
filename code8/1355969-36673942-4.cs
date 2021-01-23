    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Shape> _observableCollection;
        private int _coordinator = -1;
        private ListBox _dragSource;
        private Shape _dragedData;
        private Shape _targetData;
        private bool _isInDrag;
        public MainWindow()
        {
            InitializeComponent();
            _observableCollection = new ObservableCollection<Shape>
            {
                new Ellipse{Name = "C", Width = 50, Height = 50, Fill = Brushes.Tomato},
                new Ellipse{Name = "A", Width = 50, Height = 75, Fill = Brushes.Yellow},
                new Rectangle{Name = "Z", Width = 50, Height = 75, Fill = Brushes.Aqua},
                new Rectangle{Name = "D", Width = 50, Height = 75, Fill = Brushes.Blue},
                new Rectangle{Name = "B", Width = 50, Height = 75, Fill = Brushes.CadetBlue},   
                new Ellipse{Name = "X", Width = 75, Height = 25, Fill = Brushes.Aqua},
            };
            ListBowWithWrapPanel.ItemsSource = _observableCollection;
            Style itemContainerStyle = new Style(typeof(ListBoxItem));
            itemContainerStyle.Setters.Add(new Setter(AllowDropProperty, true));
            //we have this to handle a possible dragging element
            itemContainerStyle.Setters.Add(new EventSetter(PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(ListBowWithWrapPanel_OnPreviewMouseDown)));
            //we have this to start the dragging process
            itemContainerStyle.Setters.Add(new EventSetter(MouseMoveEvent, new MouseEventHandler(MouseMoveHandler)));
            //we have this to stop the where there is no a dragging process
            itemContainerStyle.Setters.Add(new EventSetter(MouseLeftButtonUpEvent, new MouseButtonEventHandler(LeftButtonUp)));
            //we have this to perform the drop(insert the element into a new position)
            itemContainerStyle.Setters.Add(new EventSetter(DropEvent, new DragEventHandler(ListBowWithWrapPanel_OnDrop)));
            //we have this to handle the possible target position
            itemContainerStyle.Setters.Add(new EventSetter(DragOverEvent, new DragEventHandler(OnDragOver)));
            ListBowWithWrapPanel.ItemContainerStyle = itemContainerStyle;
        }
        /// <summary>
        /// sort when button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var list = _observableCollection.ToList();
            _observableCollection.Clear();
            _coordinator *= -1;
            list.Sort((shape, shape1) =>
            {
                var name1 = shape.Name;
                var name2 = shape1.Name;
                return string.Compare(name1, name2, StringComparison.Ordinal) * _coordinator;
            });
            list.ForEach(shape =>
            {
                _observableCollection.Add(shape);
            });
        }
        /// <summary>
        /// we have this to handle a possible dragging element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBowWithWrapPanel_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = sender as ListBoxItem;
            if (listBoxItem == null) return;
            _dragSource = listBoxItem.FindParent<ListBox>();
            _dragedData = listBoxItem.DataContext as Shape;
        }
        /// <summary>
        /// we have this to start the dragging process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (_dragedData != null && _isInDrag == false)
            {
                _isInDrag = true;
                DragDrop.DoDragDrop(_dragSource, _dragedData, DragDropEffects.Move);
            }
        }
        /// <summary>
        /// we have this to handle the possible target position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dragEventArgs"></param>
        private void OnDragOver(object sender, DragEventArgs dragEventArgs)
        {
            var targetPlaceHolder = sender as ListBoxItem;
            if (targetPlaceHolder == null) return;
            _targetData = targetPlaceHolder.DataContext as Shape;
        }
        /// <summary>
        /// we have this to stop where there is no a dragging process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResumeDragging();
        }
        /// <summary>
        /// we have this to perform the drop(insert the element into a new position)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBowWithWrapPanel_OnDrop(object sender, DragEventArgs e)
        {
            if (Equals(_dragedData, _targetData)) return;
            var targetPlaceHolder = sender as ListBoxItem;
            if (targetPlaceHolder == null) return;
            var removedIdx = _observableCollection.IndexOf(_dragedData);
            var targetIdx = _observableCollection.IndexOf(_targetData);
            if (removedIdx < targetIdx)
            {
                _observableCollection.Insert(targetIdx + 1, _dragedData);
                _observableCollection.RemoveAt(removedIdx);
            }
            else
            {
                int remIdx = removedIdx + 1;
                if (_observableCollection.Count + 1 > remIdx)
                {
                    _observableCollection.Insert(targetIdx, _dragedData);
                    _observableCollection.RemoveAt(remIdx);
                }
            }
            ResumeDragging();
        }
        private void ResumeDragging()
        {
            _isInDrag = false;
            _dragedData = null;
        }
    }
