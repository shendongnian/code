    public static class ButtonAttachedProperties {
    
            public static void SetMySymbol(Button element, Symbol value) {
                element.SetValue(MySymbolProperty, value);
            }
    
            public static Symbol GetMySymbol(Button element) {
                return (Symbol) element.GetValue(MySymbolProperty);
            }
    
            // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MySymbolProperty =
                DependencyProperty.RegisterAttached("MySymbol", typeof(Symbol), typeof(ButtonAttachedProperties), new PropertyMetadata(Symbol.Bullets));
    
        }
