    public sealed partial class ModalPage : UserControl
    {
        public ModalPage()
        {
            this.InitializeComponent();
        }
    
        public static readonly DependencyProperty ModalTitleProperty = DependencyProperty.Register("ModalTitle", typeof(object), typeof(ModalPage), new PropertyMetadata(null));
    
        public object ModalTitle
        {
            get { return GetValue(ModalTitleProperty); }
            set { SetValue(ModalTitleProperty, value); }
        }
    
        public static readonly DependencyProperty ModalContentProperty = DependencyProperty.Register("ModalContent", typeof(object), typeof(ModalPage), new PropertyMetadata(null));
    
        public object ModalContent
        {
            get { return GetValue(ModalContentProperty); }
            set { SetValue(ModalContentProperty, value); }
        }
    }
