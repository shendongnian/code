    public class DatePickerDataGridColumn : DataGridColumn
    {
        public DatePickerDataGridColumn() : base() { }
        public BindingBase SelectedDateBinding { get { return _selectedDateBinding; } set { _selectedDateBinding = value; } }
        private BindingBase _selectedDateBinding = null;
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem) { return null; }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            DatePicker picker = new DatePicker();
            picker.IsEnabled = !IsReadOnly;
            picker.BorderThickness = new Thickness(0.0);
            if (SelectedDateBinding != null)
            {
                picker.SetBinding(DatePicker.SelectedDateProperty, SelectedDateBinding);
            }
            return picker;
        }
    }
