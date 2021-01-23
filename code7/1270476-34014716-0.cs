    public class VariableGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var gridViewSize = item as IGridViewSize;
            if (gridViewSize != null)
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, gridViewSize.ColumnSpan);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, gridViewSize.RowSpan);
            }
            base.PrepareContainerForItemOverride(element, item);
        }
    }
