    using Windows.UI.Xaml.Controls;
    using System.ComponentModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.UWP;
    
    [assembly: ExportRenderer(typeof(ScrollView), typeof(App3.UWP.Scrollbardisabledrenderer))]
    
    namespace App3.UWP
    {
        public class Scrollbardisabledrenderer : ScrollViewRenderer
        {
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                
    
                Control.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                Control.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
    
            }
    
    
        }
    
    }
