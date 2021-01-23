      public class MyDataGridComboBoxColumn : DataGridComboBoxColumn
      {
        public string ColumnName
        {
          get;
          set;
        }
    
        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
          var element = (dynamic)base.GenerateElement(cell, dataItem);
          ComboBox CB = new ComboBox();
          try
          {
            dynamic Value = dataItem.GetType().GetProperty(cell.Column.Header.ToString()).GetValue(dataItem, null);
            CB = new ComboBox();
            if (Value != null)
              foreach (var val in Value)
                CB.Items.Add(val);
            CB.SelectedIndex = 0;
          }
          catch { }
          return CB;
        }
      }
