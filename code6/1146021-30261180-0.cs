        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (dataGridColumnInfo.ColumnInfo == null) return;
            try
            {
                string headername = e.Column.Header.ToString();
                bool cancel = true;
                foreach (ColumnInfo colInfo in dataGridColumnInfo.ColumnInfo)
                {
                    if (colInfo.PropertyName != e.PropertyName) continue;
                    cancel = false;
                    if (e.PropertyType.IsEnum)
                    {
                        var templateColumn = new DataGridTemplateColumn();
                        templateColumn.Header = colInfo.Header;
                        templateColumn.CellTemplate = this.BuildCustomCellTemplate(colInfo.PropertyName);
                        templateColumn.CellEditingTemplate = this.BuildCustomCellEditTemplate(colInfo.PropertyName, e.PropertyType);
                        templateColumn.SortMemberPath = colInfo.PropertyName;
                        e.Column = templateColumn;
                    }
                    colInfo.Apply(e.Column);
                    break;
                }
                e.Cancel = cancel;
            }
            catch (Exception ex)
            {
                Log.CreateError("WPF", ex, Log.Priority.Emergency);
                throw;
            }
        }
        // builds custom template
        private DataTemplate BuildCustomCellTemplate(string columnName)
        {
            var template = new DataTemplate();
            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            template.VisualTree = textBlock;
            var binding = new Binding();
            binding.Path = new PropertyPath(columnName);
            binding.Converter = new EnumToStringConverter();
            textBlock.SetValue(TextBlock.TextProperty, binding);
            textBlock.SetValue(TextBlock.MarginProperty, new Thickness(0, 0, 6, 0)); 
            return template;
        }
        private DataTemplate BuildCustomCellEditTemplate(string columnName, Type enumType)
        {
            var template = new DataTemplate();
            var itemTemplate = new DataTemplate();
            var comboBox = new FrameworkElementFactory(typeof(ComboBox));
            template.VisualTree = comboBox;
            var enumList = Enum.GetValues(enumType);
            var binding = new Binding();
            binding.Source = enumList;
            comboBox.SetValue(ComboBox.ItemsSourceProperty, binding);
            var valueBinding = new Binding();
            valueBinding.Path = new PropertyPath(columnName);
            valueBinding.Mode = BindingMode.TwoWay;
            comboBox.SetValue(ComboBox.SelectedItemProperty, valueBinding);
            // Squeeze the pretty combobox in the cell
            comboBox.SetValue(ComboBox.MarginProperty, new Thickness(0));
            comboBox.SetValue(ComboBox.PaddingProperty, new Thickness(0));
            comboBox.SetValue(ComboBox.ItemTemplateProperty, itemTemplate);
            // Add the content presenter that will show the pretty value
            var content = new FrameworkElementFactory(typeof(ContentPresenter));
            itemTemplate.VisualTree = content;
            var contentBinding = new Binding();
            contentBinding.Path = new PropertyPath(".");
            contentBinding.Converter = new EnumToStringConverter();
            contentBinding.Mode = BindingMode.OneWay;
            content.SetValue(ContentPresenter.ContentProperty, contentBinding);
            content.SetValue(ContentPresenter.MarginProperty, new Thickness(0, 0, 6, 0));
            return template;
        }
