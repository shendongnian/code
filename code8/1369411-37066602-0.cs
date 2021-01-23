    public class MultiBinder : MultiBinding {
        public MultiBinder(BindingBase b1, BindingBase b2, object converter = null) {
            Bindings.Add(b1);
            Bindings.Add(b2);
            Converter = converter as IMultiValueConverter;
            CheckConverter();
        }
        public MultiBinder(BindingBase b1, BindingBase b2, BindingBase b3, object converter) {
            Bindings.Add(b1);
            Bindings.Add(b2);
            Bindings.Add(b3);
            Converter = converter as IMultiValueConverter;
            CheckConverter();
        }
        public MultiBinder(BindingBase b1, BindingBase b2, BindingBase b3, BindingBase b4, object converter) {
            Bindings.Add(b1);
            Bindings.Add(b2);
            Bindings.Add(b3);
            Bindings.Add(b4);
            Converter = converter as IMultiValueConverter;
            CheckConverter();
        }
        private void CheckConverter() {            
            if (Converter == null && DesignerProperties.GetIsInDesignMode(new DependencyObject())) {
                // if we are in design mode - feed dummy converter which cannot be called to wpf designer
                Converter = new DummyConverter();
            }
        }
        private class DummyConverter : IMultiValueConverter {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
                throw new NotSupportedException();
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
                throw new NotSupportedException();
            }
        }
    }
