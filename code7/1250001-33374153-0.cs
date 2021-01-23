    public static readonly DataViewProperty =
        DependencyProperty.Register( "DataView", typeof( CollectionViewSource ), typeof( YourControlType ),  new PropertyMetadata( null ) );
    public CollectionViewSource DataView {
        get { return (CollectionViewSource) GetProperty( DataViewProperty); }
        set { SetProperty( DataViewProperty, value );
    }
