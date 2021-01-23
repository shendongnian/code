    public class Pin : Control {
        public DataTemplate DescriptionItemTemplate {
            get { return (DataTemplate)GetValue(DescriptionItemTemplateProperty); }
            set { SetValue(DescriptionItemTemplateProperty, value); }
        }
        public static readonly DependencyProperty DescriptionItemTemplateProperty =
            DependencyProperty.Register("DescriptionItemTemplate", typeof(DataTemplate), typeof(Pin), new PropertyMetadata(null));
        ControlAdorner _adorner;
        AdornerLayer _adornerLayer;
        static Pin() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pin), new FrameworkPropertyMetadata(typeof(Pin)));
        }
        
        public Pin() {
            this.MouseEnter += Pin_MouseEnter;
            this.MouseLeave += Pin_MouseLeave;
        }
        private void Pin_MouseEnter(object sender, MouseEventArgs e) {
            _adornerLayer = AdornerLayer.GetAdornerLayer(this);
            FrameworkElement element = DescriptionItemTemplate.LoadContent() as FrameworkElement;
            if (element == null) { return; }
            element.DataContext = this.DataContext;
            _adorner = new ControlAdorner(this, element);
            _adornerLayer.Add(_adorner);
        }
        private void Pin_MouseLeave(object sender, MouseEventArgs e) {
            _adornerLayer.Remove(_adorner);
            _adorner = null;
        }
    }
