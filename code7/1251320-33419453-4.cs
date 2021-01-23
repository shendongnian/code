    public class ChangeTemplateBehavior : System.Windows.Interactivity.Behavior<Button>
    {
        public static readonly DependencyProperty ControlTemplate1Property = DependencyProperty.Register("ControlTemplate1", typeof(ControlTemplate), typeof(ChangeTemplateBehavior), new PropertyMetadata(default(ControlTemplate)));
        public ControlTemplate ControlTemplate1
        {
            get
            {
                return (ControlTemplate)GetValue(ControlTemplate1Property);
            }
            set
            {
                SetValue(ControlTemplate1Property, value);
            }
        }
        public static readonly DependencyProperty ControlTemplate2Property = DependencyProperty.Register("ControlTemplate2", typeof(ControlTemplate), typeof(ChangeTemplateBehavior), new PropertyMetadata(default(ControlTemplate)));
        public ControlTemplate ControlTemplate2
        {
            get
            {
                return (ControlTemplate)GetValue(ControlTemplate2Property);
            }
            set
            {
                SetValue(ControlTemplate2Property, value);
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Click += AssociatedObject_Click;
        }
        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            if (this.AssociatedObject.Template == this.ControlTemplate2)
            {
                this.AssociatedObject.Template = this.ControlTemplate1;
            }
            else
            {
                this.AssociatedObject.Template = this.ControlTemplate2;
            }
        }
    }
