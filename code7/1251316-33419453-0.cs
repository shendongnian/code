    public class ChangeTemplateBehavior : System.Windows.Interactivity.Behavior<Button>
    {
        public static readonly DependencyProperty ControlTemplateProperty = DependencyProperty.Register("ControlTemplate", typeof(ControlTemplate), typeof(ChangeTemplateBehavior), new PropertyMetadata(default(ControlTemplate)));
        public ControlTemplate ControlTemplate
        {
            get
            {
                return (ControlTemplate)GetValue(ControlTemplateProperty);
            }
            set
            {
                SetValue(ControlTemplateProperty, value);
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Click += AssociatedObject_Click;
        }
        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Template = this.ControlTemplate;
        }
    }
