    using System.Linq;
    using Windows.UI;
    using Windows.UI.Xaml.Controls;
    using System.Reflection;
    
    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent( );
    
                // just some sample data
                var colors = typeof( Colors )
                    .GetRuntimeProperties( )
                    .Take( 140 )
                    .Select( ( x, index ) => new
                    {
                        Color = (Color) x.GetValue( null ),
                        Name = x.Name,
                        Index = index,
                    } );
                this.DataContext = colors;
            }
    
        }
    }
