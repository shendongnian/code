            var column = new GridViewColumn { Header = "" };
            var customTemplate = new System.Windows.DataTemplate();
            var efImage = new FrameworkElementFactory(typeof(Image));
            efImage.SetBinding(Image.SourceProperty, new Binding("Icon"));
            customTemplate.VisualTree = efImage;
            column.CellTemplate = customTemplate;
            view.Columns.Add(column);
