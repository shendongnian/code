    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public class MyGridViewTemplateSelector : DataTemplateSelector
        {
            public DataTemplate Small { get; set; }
            public DataTemplate Medium { get; set; }
            public DataTemplate Large { get; set; }
    
            protected override DataTemplate SelectTemplateCore( object item, DependencyObject container )
            {
                var rowSpan = container.GetValue( VariableSizedWrapGrid.RowSpanProperty );
    
                int index;
                try
                {
                    dynamic model = item;
                    index = model.Index;
                }
                catch ( Exception )
                {
                    index = -1;
                }
                long token = 0;
    
                DependencyPropertyChangedCallback lambda = ( sender, dp ) =>
                {
                    container.UnregisterPropertyChangedCallback( VariableSizedWrapGrid.RowSpanProperty, token );
    
                    var cp = (ContentControl) container;
                    cp.ContentTemplateSelector = null;
                    cp.ContentTemplateSelector = this;
                };
    
                token = container.RegisterPropertyChangedCallback( VariableSizedWrapGrid.RowSpanProperty, lambda );
    
                switch ( rowSpan )
                {
                    case 1:
                        return Small;
                    case 2:
                        return Medium;
                    case 3:
                        return Large;
                    default:
                        throw new InvalidOperationException( );
                }
            }
    
            private void Foo( DependencyObject sender, DependencyProperty dp )
            {
                throw new NotImplementedException( );
            }
        }
    }
