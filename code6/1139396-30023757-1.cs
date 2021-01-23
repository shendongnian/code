    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace Silverlight80App
    {
      class Tile : ContentControl
      {
        public static readonly DependencyProperty TileColorProperty =
          DependencyProperty.Register("TileColor", typeof(Brush), typeof(Tile),
          null);
        public Brush TileColor
        {
          get { return (Brush)GetValue(TileColorProperty); }
          set { SetValue(TileColorProperty, value); }
        }
        public Tile()
        {
          DefaultStyleKey = typeof(Tile);
        }
      }
    }
