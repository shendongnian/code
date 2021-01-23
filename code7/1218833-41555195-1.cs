    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Foundation;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public class MyGridView : GridView
        {
            private int _columnCount = 1;
            private double _itemWidth = 100;
    
            public double MinItemWidth
            {
                get { return (double) GetValue( MinItemWidthProperty ); }
                set { SetValue( MinItemWidthProperty, value ); }
            }
    
            // Using a DependencyProperty as the backing store for MinItemWidth.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MinItemWidthProperty =
                DependencyProperty.Register( "MinItemWidth", typeof( double ), typeof( MyGridView ), new PropertyMetadata( 100.0 ) );
    
    
            public double MaxItemWidth
            {
                get { return (double) GetValue( MaxItemWidthProperty ); }
                set { SetValue( MaxItemWidthProperty, value ); }
            }
    
            // Using a DependencyProperty as the backing store for MaxItemWidth.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MaxItemWidthProperty =
                DependencyProperty.Register( "MaxItemWidth", typeof( double ), typeof( MyGridView ), new PropertyMetadata( 200.0 ) );
    
    
            private long _itemsPanelPropertyChangedToken;
    
            public MyGridView()
            {
                _itemsPanelPropertyChangedToken = RegisterPropertyChangedCallback( ItemsPanelProperty, ItemsPanelChangedAsync );
            }
    
            private async void ItemsPanelChangedAsync( DependencyObject sender, DependencyProperty dp )
            {
                UnregisterPropertyChangedCallback( ItemsPanelProperty, _itemsPanelPropertyChangedToken );
                await this.Dispatcher.RunIdleAsync( ItemsPanelChangedCallback );
            }
    
            private void ItemsPanelChangedCallback( IdleDispatchedHandlerArgs e )
            {
                var wg = ItemsPanelRoot as VariableSizedWrapGrid;
                if (wg != null)
                {
                    wg.ItemWidth = _itemWidth;
                }
            }
    
            protected override void PrepareContainerForItemOverride( DependencyObject element, object item )
            {
                var itemIndex = this.Items.IndexOf( item );
    
                element.SetValue( VariableSizedWrapGrid.RowSpanProperty, GetRowSpanByColumnCountAndIndex( _columnCount, itemIndex ) );
                element.SetValue( VerticalContentAlignmentProperty, VerticalAlignment.Stretch );
                element.SetValue( HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch );
                base.PrepareContainerForItemOverride( element, item );
            }
    
            private static readonly Dictionary<int, int[]> _rowSpanLayout = new Dictionary<int, int[]>
            {
                [ 1 ] = new int[] { /* 5 */ 2, 2, 2, 2, 2, /* 6 */ 2, 2, 2, 2, 2, 2, /* 7 */ 2, 2, 2, 2, 2, 2, 2, /* 8 */ 2, 2, 2, 2, 2, 2, 2, 2, /* 9 */ 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                [ 2 ] = new int[] { /* 5 */ 2, 1, 2, 2, 1, /* 6 */ 3, 3, 3, 2, 2, 2, /* 7 */ 3, 3, 1, 2, 3, 1, 1, /* 8 */ 2, 3, 2, 3, 3, 3, 3, 1, /* 9 */ 3, 2, 1, 3, 2, 2, 3, 1, 1 },
                [ 3 ] = new int[] { /* 5 */ 3, 2, 2, 1, 1, /* 6 */ 2, 3, 2, 3, 3, 2, /* 7 */ 3, 3, 3, 2, 1, 2, 1, /* 8 */ 2, 3, 3, 1, 2, 1, 2, 1, /* 9 */ 3, 3, 3, 1, 2, 1, 3, 3, 2 },
                [ 4 ] = new int[] { /* 5 */ 2, 2, 1, 2, 1, /* 6 */ 3, 3, 2, 2, 1, 1, /* 7 */ 3, 2, 2, 2, 1, 1, 1, /* 8 */ 3, 3, 3, 3, 2, 2, 2, 2, /* 9 */ 3, 3, 3, 2, 2, 2, 2, 2, 1 },
                [ 5 ] = new int[] { /* 5 */ 2, 2, 2, 2, 2, /* 6 */ 2, 2, 2, 1, 2, 1, /* 7 */ 3, 3, 3, 2, 2, 1, 1, /* 8 */ 3, 3, 2, 2, 2, 1, 1, 1, /* 9 */ 3, 2, 2, 2, 2, 1, 1, 1, 1 },
            };
    
            private int GetRowSpanByColumnCountAndIndex( int columnCount, int itemIndex )
            {
                return _rowSpanLayout[ columnCount ][ itemIndex % 35 ];
            }
    
            protected override Size MeasureOverride( Size availableSize )
            {
                System.Diagnostics.Debug.WriteLine( availableSize );
    
                int columnCount = _columnCount;
                double availableWidth = availableSize.Width;
    
                double itemWidth = availableWidth / columnCount;
    
                while ( columnCount > 1 && itemWidth < Math.Min( MinItemWidth, MaxItemWidth ) )
                {
                    columnCount--;
                    itemWidth = availableWidth / columnCount;
                }
    
                while ( columnCount < 5 && itemWidth > Math.Max( MinItemWidth, MaxItemWidth ) )
                {
                    columnCount++;
                    itemWidth = availableWidth / columnCount;
                }
    
                var wg = this.ItemsPanelRoot as VariableSizedWrapGrid;
    
                _itemWidth = itemWidth;
                if ( _columnCount != columnCount )
                {
                    _columnCount = columnCount;
                    if ( wg != null )
                    {
                        Update( );
                    }
                }
    
                if ( wg != null )
                {
                    wg.ItemWidth = itemWidth;
                }
    
                return base.MeasureOverride( availableSize );
            }
    
            // refresh the variablesizedwrapgrid layout
            private void Update()
            {
                if ( !( this.ItemsPanelRoot is VariableSizedWrapGrid ) )
                    throw new ArgumentException( "ItemsPanel is not VariableSizedWrapGrid" );
    
                int itemIndex = 0;
                foreach ( var container in this.ItemsPanelRoot.Children.Cast<GridViewItem>( ) )
                {
                    int rowSpan = GetRowSpanByColumnCountAndIndex( _columnCount, itemIndex );
                    VariableSizedWrapGrid.SetRowSpan( container, rowSpan );
                    itemIndex++;
                }
    
                this.ItemsPanelRoot.InvalidateMeasure( );
            }
        }
    }
