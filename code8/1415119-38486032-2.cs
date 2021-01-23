    public class MyBorderBehavior : Behavior<Control>
        {
            public MyEnum MyEnumPropery {
                get { return (MyEnum) GetValue(MyEnumProperyProperty); }
                set { SetValue(MyEnumProperyProperty, value); }
            }
    
            public static readonly DependencyProperty MyEnumProperyProperty = DependencyProperty.Register("MyEnumPropery", typeof(MyEnum), typeof(MyBorderBehavior), new PropertyMetadata(PropertyChangedCallback));
    
            private static void PropertyChangedCallback(DependencyObject dO, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
            {
                var self = dO as MyBorderBehavior;
                if (self != null && self._controlToColorBorder != null)
                    self.SetColor();
            }
    
            private Control _controlToColorBorder;
    
            private void SetColor()
            {
                switch (this.MyEnumPropery)
                {
                    case MyEnum.One:
                        this._controlToColorBorder.BorderBrush = Brushes.Yellow;
                        break;
                    case MyEnum.Two:
                        this._controlToColorBorder.BorderBrush = Brushes.Red;
                        break;
                    case MyEnum.Three:
                        this._controlToColorBorder.BorderBrush = Brushes.Green;
                        break;
                    case MyEnum.Four:
                        this._controlToColorBorder.BorderBrush = Brushes.DeepPink;
                        break;
                }
            }
    
            protected override void OnAttached()
            {
                this._controlToColorBorder = this.AssociatedObject;
                this._controlToColorBorder.Loaded += ControlToColorBorderLoaded;
                base.OnAttached();
            }
    
            private void ControlToColorBorderLoaded(object sender, RoutedEventArgs e)
            {
                this.SetColor();
            }
        }
