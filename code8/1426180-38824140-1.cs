    public class ColorSlider : Slider {
            static ColorSlider() {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSlider), new FrameworkPropertyMetadata(typeof(ColorSlider)));
            }
    
            #region Dependency Properties
    
            public Color LeftColor {
                get { return (Color) GetValue(LeftColorProperty); }
                set { SetValue(LeftColorProperty, value); }
            }
            public static readonly DependencyProperty LeftColorProperty =
            DependencyProperty.Register("LeftColor", typeof(Color), typeof(ColorSlider), new UIPropertyMetadata(Colors.Black));
    
            public Color RightColor {
                get { return (Color) GetValue(RightColorProperty); }
                set { SetValue(RightColorProperty, value); }
            }
            public static readonly DependencyProperty RightColorProperty =
            DependencyProperty.Register("RightColor", typeof(Color), typeof(ColorSlider), new UIPropertyMetadata(Colors.White));
    
            #endregion
    
    
            private bool _isPressed = false;
    
            protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
                base.OnPreviewMouseLeftButtonDown(e);
                _isPressed = true;
                if (_isPressed) {
                    Point position = e.GetPosition(this);
                    double d = 1.0d / this.ActualWidth * position.X;
                    var p = this.Maximum * d;
                    this.Value = p;
                }
                e.Handled = true;
            }
    
            protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e) {
                base.OnPreviewMouseLeftButtonUp(e);
                _isPressed = false;
            }
    
            protected override void OnMouseMove(MouseEventArgs e) {
                if (_isPressed) {
                    Point position = e.GetPosition(this);
                    double d = 1.0d / this.ActualWidth * position.X;
                    var p = this.Maximum * d;
                    this.Value = p;
                }
            }
        }
