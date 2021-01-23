    class DataGridTemplateColumnEx : DataGridTemplateColumn
    {
        public string ColumnName { get; set; }
    
        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            // The DataGridTemplateColumn uses ContentPresenter with your DataTemplate.
            var cp = (ContentPresenter)base.GenerateElement(cell, dataItem);
            // Reset the Binding to the specific column. The default binding is to the DataRowView.
            BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, new Binding(this.ColumnName));
            return cp;
        }
    
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            // Create our ObjectProxy that will update our dataItem's ColumnName property
            var op = new ObjectProxy(dataItem, ColumnName);
            // Generate the editing element using our ObjectProxy
            var cp = (ContentPresenter)base.GenerateEditingElement(cell, op);
            // Reset the Binding to our ObjectProxy
            BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, new Binding(".") { Source = op });
            return cp;
        }
    
        private void DisposeOfProxyObject(FrameworkElement editingElement)
        {
            var cp = editingElement as ContentPresenter;
            if (cp != null)
            {
                var op = cp.Content as ObjectProxy;
                if (op != null)
                    op.Dispose();
            }
        }
    
        protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue)
        {
            DisposeOfProxyObject(editingElement);
            base.CancelCellEdit(editingElement, uneditedValue);
        }
    
        protected override bool CommitCellEdit(FrameworkElement editingElement)
        {
            DisposeOfProxyObject(editingElement);
            return base.CommitCellEdit(editingElement);
        }
    }
