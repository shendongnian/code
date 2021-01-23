    public sealed partial class EditablePanel : UserControl
    {
        public EditablePanel()
        {
            this.InitializeComponent();
        }
    
        public void SetInEditMode()
        {
            VisualStateManager.GoToState(this, "Selected", true);
        }
    
        public void SetInViewMode()
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }
    }
