    public class ComboboxExpandingBehavior : Behavior<EditableMultiSelectComboBoxEdit>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.IsVisibleChanged += OnVisibleChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.IsVisibleChanged -= OnVisibleChanged;
            base.OnDetaching();
        }
        private void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var cb = sender as EditableMultiSelectComboBoxEdit;
            if (cb != null)
            {
                cb.IsPopupOpen = cb.IsVisible;
            }
        }
    }
