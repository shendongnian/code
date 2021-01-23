    public partial class TileBlock : UserControl {
      public TileBlock() {
        InitializeComponent();
      }
      //Dependency properties for backgrounds
      public Brush LeftBlockBackground {
        get { return (Brush)GetValue(LeftBlockBackgroundProperty); }
        set { SetValue(LeftBlockBackgroundProperty, value); }
      }
      public static readonly DependencyProperty LeftBlockBackgroundProperty =
          DependencyProperty.Register("LeftBlockBackground", typeof(Brush), typeof(TileBlock), new PropertyMetadata(Brushes.Transparent));
      //... repeat for Top, Right, Bottom and Central
      
      public event MouseButtonEventHandler LeftBlockMouseDown;
      private void LeftBlock_MouseDown(object sender, MouseButtonEventArgs e) {
        if (LeftBlockMouseDown != null) LeftBlockMouseDown(this, e);
        e.Handled = true;
      }
      //... repeat for Top, Right, Bottom and Central
      
      //... repeat for MouseEnter, MouseLeave, MouseMove etc. if necessary
    }
