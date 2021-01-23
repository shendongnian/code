      public class DynamicDataGridTemplateColumn : DataGridTemplateColumn
      {
        public string ColumnName
        {
          get;
          set;
        }
    
        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
          // The DataGridTemplateColumn uses ContentPresenter with your DataTemplate.
          ContentPresenter cp = (ContentPresenter)base.GenerateElement(cell, dataItem);
          // Reset the Binding to the specific column. The default binding is to the DataRowView.
          BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, new Binding(this.ColumnName));
          return cp;
        }
      }
