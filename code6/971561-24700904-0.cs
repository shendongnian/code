        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            DatePicker dp = new DatePicker();
            dp.Name = "datePicker";
            CustomControlHelper.ApplyBinding(dp, DatePicker.SelectedDateProperty, this.Binding);
            dp.PreviewKeyDown += DatePicker_OnPreviewKeyDown;
            return (FrameworkElement)dp;
        }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock tb = new TextBlock();
            CustomControlHelper.ApplyBinding(tb, TextBlock.TextProperty, this.Binding);            
            cell.TextInput += OnCellTextInput;            
            return (FrameworkElement)tb;
        }
        
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            DatePicker picker = editingElement as DatePicker;
            DateTime newValue = DateTime.Today;
            if (picker != null)
            {
                DateTime? dt = picker.SelectedDate;
                if (dt.HasValue)
                {
                    newValue = dt.Value;
                }
            }            
            
            picker.Focus();
            return newValue;
        }       
