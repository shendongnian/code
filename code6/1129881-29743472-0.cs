    public static readonly DependencyProperty MyItemsProperty =
         DependencyProperty.RegisterAttached("MyItems", 
                                            typeof(ObservableCollection<BoundItem>), 
                                            typeof(FrameworkElementDropBehavior), 
                                            new FrameworkPropertyMetadata(null));
