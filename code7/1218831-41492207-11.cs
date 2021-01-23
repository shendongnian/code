    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent( );
        }
        public int ColumnCount
        {
            get { return (int) GetValue( ColumnCountProperty ); }
            private set { SetValue( ColumnCountProperty, value ); }
        }
        // Using a DependencyProperty as the backing store for ColumnCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register( "ColumnCount", typeof( int ), typeof( MainWindow ), new PropertyMetadata( 1 ) );
        public double ColumnWidth
        {
            get { return (double) GetValue( ColumnWidthProperty ); }
            private set { SetValue( ColumnWidthProperty, value ); }
        }
        // Using a DependencyProperty as the backing store for ColumnWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnWidthProperty =
            DependencyProperty.Register( "ColumnWidth", typeof( double ), typeof( MainWindow ), new PropertyMetadata( (double) 100 ) );
        public double ColumnMinWidth
        {
            get { return (double) GetValue( ColumnMinWidthProperty ); }
            set
            {
                SetValue( ColumnMinWidthProperty, value );
                CalculateColumnLayout( );
            }
        }
        // Using a DependencyProperty as the backing store for ColumnMinWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnMinWidthProperty =
            DependencyProperty.Register( "ColumnMinWidth", typeof( double ), typeof( MainWindow ), new PropertyMetadata( (double) 200 ) );
        public double ColumnMaxWidth
        {
            get { return (double) GetValue( ColumnMaxWidthProperty ); }
            set
            {
                SetValue( ColumnMaxWidthProperty, value );
                CalculateColumnLayout( );
            }
        }
        // Using a DependencyProperty as the backing store for ColumnMaxWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnMaxWidthProperty =
            DependencyProperty.Register( "ColumnMaxWidth", typeof( double ), typeof( MainWindow ), new PropertyMetadata( (double) 250 ) );
        private void CalculateColumnLayout()
        {
            int colCount = ColumnCount;
            double totalWidth = ItemsPresenter.ActualWidth;
            double colWidth = totalWidth / colCount;
            while ( colCount > 1 && colWidth < Math.Min( ColumnMinWidth, ColumnMaxWidth ) )
            {
                colCount--;
                colWidth = totalWidth / colCount;
            }
            while ( colCount < 5 && colWidth > Math.Max( ColumnMinWidth, ColumnMaxWidth ) )
            {
                colCount++;
                colWidth = totalWidth / colCount;
            }
            if ( ColumnCount != colCount )
            {
                ColumnCount = colCount;
                StyleItemsPresenterItems( );
            }
            ColumnWidth = colWidth;
        }
        private Dictionary<int, string[]> _styles = new Dictionary<int, string[]>
        {
            [ 1 ] = new string[] { "medium", "medium", "medium", "medium", "medium", "medium" },
            [ 2 ] = new string[] { "large", "medium", "small", "small", "medium", "large" },
            [ 3 ] = new string[] { "large", "medium", "medium", "large", "large", "medium" },
            [ 4 ] = new string[] { "large", "large", "large", "small", "small", "small" },
            [ 5 ] = new string[] { "medium", "medium", "medium", "medium", "small", "small" },
        };
        private void StyleItemsPresenterItems()
        {
            foreach ( var pnl in ItemsPresenter.Items.OfType<WrapPanel>( ) )
            {
                if ( pnl != null )
                {
                    pnl.Style = ItemsPresenter.Resources[ $"{ColumnCount}col6items" ] as Style;
                    foreach ( var item in pnl.Children.OfType<TextBlock>( ).Zip( _styles[ ColumnCount ], ( border, stylename ) => new { border, stylename } ) )
                    {
                        item.border.Style = ItemsPresenter.Resources[ item.stylename ] as Style;
                    }
                }
            }
        }
        private void ItemsPresenter_SizeChanged( object sender, SizeChangedEventArgs e )
        {
            CalculateColumnLayout( );
        }
    }
