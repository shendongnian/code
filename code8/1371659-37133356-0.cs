    // Provide a dependency property to enable binding
    public static readonly DependencyProperty MyPointsProperty = DependencyProperty.Register( "MyPoints", typeof(ObservableCollection<Points>) ,new FrameworkPropertyMetadata( null, FrameworkPopertyMetatdataOptions.None, MyPointsPropertyChangedHandler ) );
    // Provide a CLR property for convenience - this will not get called by the binding engine!
    public ObservableCollection<Points> MyPoints {
        get { return (ObservableCollection<Points>) GetValue( MyPointsProperty ); } 
        set { SetValue( MyPointsProperty, value ); }
    }
    //Listen for changes to the dependency property (note this is a static method)
    public static void MyPointsPropertyChanged( DependencyObject obj, DependencyPropertyChangedEventArgs e) {
        MyControl me = obj as MyControl;
        if( me != null ) {
            // Call a non-static method on the object whose property has changed
            me.OnMyPointsChanged( (ObservableCollection<Points>) e.OldValue, (ObservableCollection<Points>) e.NewValue );
        }
    }
    // ...
    // Listen for changes to the property (non-static) to register CollectionChanged handlers
    protected virtual void OnMyPointsChanged(ObservableCollection<Points> oldValue, ObservableCollection<Points> newValue) {
        if(oldValue!=null){
            oldValue.CollectionChanged -= MyCollectionChangedHandler;
        }
        if( newValue!=null ) {
            newValue.CollectionChanged += MyCollectionChangedHandler;
        }
    }
