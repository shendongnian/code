    public partial class MainWindow : Window
    {
        TreeViewModel TreeViewModel_After;
        public MainWindow()
        {
            TreeViewModel_After = new TreeViewModel();
            TreeViewModel_After.Items = new ObservableCollection<NodeViewModel>{
                           new NodeViewModel { Name = "Root", Children =  new ObservableCollection<NodeViewModel> {
                              new NodeViewModel { Name = "Level1" ,  Children = new ObservableCollection<NodeViewModel>{ 
                                  new NodeViewModel{ Name = "Level2"}}} } }};
            InitializeComponent();
        }
        public TreeViewModel TreeModel
        {
            get
            {
                return TreeViewModel_After;
            }
        }
        Point _lastMouseDown;
        NodeViewModel draggedItem, _target;
        private void TreeView_After_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _lastMouseDown = e.GetPosition(TreeView_After);
            }
        }
        private bool CheckGridSplitter(UIElement element)
        {
            if (element is GridSplitter)
            {
                return true;
            }
            GridSplitter GridSplitter = FindParent<GridSplitter>(element);
            if (GridSplitter != null)
            {
                return true;
            }
            return false;
        }
        private void TreeView_After_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    UIElement element = e.OriginalSource as UIElement;
                    bool bGridSplitter = CheckGridSplitter(element);
                    Point currentPosition = e.GetPosition(TreeView_After);
                    if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                        (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                    {
                        draggedItem = (NodeViewModel)TreeView_After.SelectedItem;
                        if ( (draggedItem != null) && !bGridSplitter)
                        {
                            DragDropEffects finalDropEffect = DragDrop.DoDragDrop(TreeView_After, TreeView_After.SelectedValue,
                                DragDropEffects.Move);
                            //Checking target is not null and item is dragging(moving)
                            if ((finalDropEffect == DragDropEffects.Move) && (_target != null))
                            {
                                
                                // A Move drop was accepted
                                if (draggedItem.Name != _target.Name)
                                {
                                    CopyItem(draggedItem, _target);
                                    _target = null;
                                    draggedItem = null;
                                }      
                                 
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void TreeView_After_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point currentPosition = e.GetPosition(TreeView_After);
                if ((Math.Abs(currentPosition.X - _lastMouseDown.X) > 10.0) ||
                    (Math.Abs(currentPosition.Y - _lastMouseDown.Y) > 10.0))
                {
                    // Verify that this is a valid drop and then store the drop target
                    NodeViewModel item = GetNearestContainer(e.OriginalSource as UIElement);
                    if (CheckDropTarget(draggedItem, item))
                    {
                        e.Effects = DragDropEffects.Move;
                    }
                    else
                    {
                        e.Effects = DragDropEffects.None;
                    }
                }
                e.Handled = true;
            }
            catch (Exception)
            {
            }
        }
        private void TreeView_After_Drop(object sender, DragEventArgs e)
        {
            try
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
                // Verify that this is a valid drop and then store the drop target
                NodeViewModel TargetItem = GetNearestContainer(e.OriginalSource as UIElement);
                if (TargetItem != null && draggedItem != null)
                {
                    _target = TargetItem;
                    e.Effects = DragDropEffects.Move;
                }
            }
            catch (Exception)
            {
            }
        }
        private bool CheckDropTarget(NodeViewModel _sourceItem, NodeViewModel _targetItem)
        {
            //Check whether the target item is meeting your condition
            bool _isEqual = false;
            if(_sourceItem.Name != _targetItem.Name )
            {
                _isEqual = true;
            }
             
            return _isEqual;
        }
        
        private void CopyItem(NodeViewModel _sourceItem, NodeViewModel _targetItem)
        {
            //Asking user wether he want to drop the dragged TreeViewItem here or not
            if (MessageBox.Show("Would you like to drop " + _sourceItem.Name + " into " + _targetItem.Name + "", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    _targetItem.Children.Add(_sourceItem);
                }
                catch (Exception)
                {
                }
            }
        }
         
        private NodeViewModel GetNearestContainer(UIElement element)
        {
            // Walk up the element tree to the nearest tree view item.
            TreeViewItem UIContainer = FindParent<TreeViewItem>(element);
            NodeViewModel NVContainer = null;
            if (UIContainer != null)
            {
                NVContainer = UIContainer.DataContext as NodeViewModel;
            }
            return NVContainer;
        }
        private static Parent FindParent<Parent>(DependencyObject child)
                where Parent : DependencyObject
        {
            DependencyObject parentObject = child;
            parentObject = VisualTreeHelper.GetParent(parentObject);
            //check if the parent matches the type we're looking for
            if (parentObject is Parent || parentObject == null)
            {
                return parentObject as Parent;
            }
            else
            {
                //use recursion to proceed with next level
                return FindParent<Parent>(parentObject);
            }
        }
    }
