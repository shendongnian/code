    public class CustomSlider : Slider
    {
        private Binding SupressedBinding { get; set; }
        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            base.OnThumbDragStarted(e);
            var expression = BindingOperations.GetBindingExpression(this, ValueProperty);
            if (expression != null)
            {
                SupressedBinding = expression.ParentBinding;
                //clearing the binding will cause the Value to reset to default,
                //so we'll need to restore it
                var value = Value;
                BindingOperations.ClearBinding(this, ValueProperty);
                SetValue(ValueProperty, value);
            }
        }
        protected override void OnThumbDragCompleted(DragCompletedEventArgs e)
        {
            if (SupressedBinding != null)
            {
                //again, restoring the binding will cause the Value to update to source's
                //value (which is "out of date" by now), so we'll need to restore it
                var value = Value;
                BindingOperations.SetBinding(this, ValueProperty, SupressedBinding);
                SetCurrentValue(ValueProperty, value);
                SupressedBinding = null;
            }
            base.OnThumbDragCompleted(e);
        }
    }
